using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiberyShop.Model
{
    [Table("user", Schema = "public")]
    public class User
    {
        /// <summary>
        /// User id 
        /// </summary>
        [Column("id")]
        public int Id { get; set; }
        /// <summary>
        /// user Login
        /// </summary>
        [Column("login")]
        public string Login { get; set; }
        /// <summary>
        /// user password
        /// </summary>
        [Column("password")]
        public string Password { get; set; }
    }
}
