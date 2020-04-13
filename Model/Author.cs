using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiberyShop.Model
{
    [Table("author", Schema = "public")]
    public class Author
    {
        /// <summary>
        /// author id
        /// </summary>
        [Column("id")]
        public int Id { get; set; }
        /// <summary>
        /// author name
        /// </summary>
        [Column("name")]
        public string AuthorName { get; set; }
    }
}
