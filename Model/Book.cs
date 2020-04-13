using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LiberyShop.Model
{
    [Table("book", Schema = "public")]
    public class Book
    {
        /// <summary>
        /// book id
        /// </summary>
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// book name
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// book author
        /// </summary>
        [Column("author_id")]
        [ForeignKey("AuthorModel")]
        public int AuthorId { get; set; }

        /// <summary>
        /// forinkey
        /// </summary>
        [IgnoreDataMember]
        public virtual Author AuthorModel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("book_url")]
        public string BookUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("photourl")]
        public string PhotoUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("user_id")]
        [ForeignKey("UserModel")]
        public int? UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember]
        public virtual User UserModel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("sort_id")]
        [ForeignKey("BookSortModel")]
        public int? BookSort { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        [IgnoreDataMember]
        public virtual BookSort BookSortModel { get; set; }
    }
}
