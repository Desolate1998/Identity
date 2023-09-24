using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityPackage.Models.Database
{
    public class IdentityLoginStatus
    {
        /// <summary>
        /// Row entry Id
        /// </summary>
        [Column("Login_Status_Id")]
        public long LoginStatusId { get; set; }

        /// <summary>
        /// ID used to determine the user login requests
        /// </summary>
        [Column("Login_Status_Id")]
        public string SessionId { get; set; }

        /// <summary>
        /// ID used to determine the user login requests
        /// </summary>
        [Column("Login_results")]
        public bool Results { get; set; }

        /// <summary>
        /// The date the login was attempted
        /// </summary>
        [Column("Date")]
        public DateTime Date { get; set; }
    }
}
