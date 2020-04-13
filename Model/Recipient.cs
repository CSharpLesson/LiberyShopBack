using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiberyShop.Model
{
    [Table("recpient", Schema = "public")]
    public class Recipient
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("id")]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("user_id")]
        public int UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("book_id")]
        public int BookId { get; set; }
        /// <summary>
        /// date Start
        /// </summary>
        [Column("date_start")]
        public DateTime DateStart { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("date_end")]
        public DateTime DateEnd { get; set; }

    }
}
