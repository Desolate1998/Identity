// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Critical Code Smell", "S2223:Non-constant static fields should not be visible", Justification = "Need it to be public so the password rules can be set", Scope = "member", Target = "~F:IdentityPackage.IdentitityInternalServices.PasswordService.options")]
