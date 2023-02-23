﻿using IdentityPackage.Models.Interfaces;
using IdentityPackage.Models.Structs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace IdentityPackage.Core
{
  public class IdentityAuthorization : IIdentityAuthorization
  {

    private readonly RequestDelegate _next;
    private readonly ILogger<IdentityAuthorization> _logger;
    private readonly IActionControllerInformation _controllerActions;
    private readonly IIdentityTokenService _tokenServices;

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="next">Next middle ware to be executed</param>
    /// <param name="logger">Logger helper</param>
    /// <param name="tokenServices">Token class service</param>
    /// <param name="controllerActions">Controller actions</param>
    /// <exception cref="ArgumentNullException">Exception thrown when any of the arguments are null</exception>
    public IdentityAuthorization(RequestDelegate next, ILogger<IdentityAuthorization> logger,  IIdentityTokenService tokenServices, IActionControllerInformation controllerActions)
    {
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
      _next = next ?? throw new ArgumentNullException(nameof(next)); 
      _tokenServices = tokenServices ??  throw new ArgumentNullException(nameof(tokenServices));
      _controllerActions = controllerActions;
    }

    /// <summary>
    /// Validates the user authorization to the action which they are requesting.
    /// </summary>
    /// <param name="context">The context</param>
    public Task Invoke(HttpContext context)
    {
      try
      {
        if (ValidateForToken(context))
        {
          string? token = context.Request.Headers["Authorization"].FirstOrDefault();

          if (token is null)
          {
            _logger.LogInformation($"Received unauthorized request [Missing Bearer token] at :[{DateTime.UtcNow}]");
            context.Response.Clear();
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Response.WriteAsync("Unauthorized").Wait();
            return Task.CompletedTask;
          }
          else
          {
            var test = _tokenServices.ValidateToken(token.Replace("Bearer ",""));
            return _next.Invoke(context);
          }
        }
        else
        {
          return _next.Invoke(context);
        }
      }
      catch (Exception ex)
      {
        _logger.LogInformation(message: $"An exception occurred while trying to validate route authorization. Message :[{ex.Message}]");
        context.Response.Clear();
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.WriteAsync("Server error").Wait();
        return Task.CompletedTask;
      }
    }

    /// <summary>
    /// Validates the route to see if a bearer token is required
    /// </summary>
    /// <param name="context">The request context</param>
    /// <returns>Boolean to see if authentication should be done to the action and route</returns>
    /// <exception cref="NullReferenceException">When the route or action could not be located</exception>
    private bool ValidateForToken(HttpContext context)
    {
      IReadOnlyDictionary<string, object> ? routeValues = ((dynamic)context.Request).RouteValues as IReadOnlyDictionary<string, object>
                                                        ?? throw new NullReferenceException($"{nameof(routeValues)}");
      
      string controller = routeValues["Controller"].ToString() ?? throw new NullReferenceException($"{nameof(controller)}");
      string action = routeValues["Action"].ToString() ?? throw new NullReferenceException($"{nameof(action)}");
      return _controllerActions.ActionInformation.Where(x => x.Controller == controller && x.Action == action).Any();
    }

  }
}
