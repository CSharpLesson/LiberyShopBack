using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiberyShop.Model
{
    public class AuthUIElements
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Объектнинг қисқача коди
        /// </summary>
        [Column("element_code")]
        public string ElementCode { get; set; }


        /// <summary>
        /// Изоҳ
        /// </summary>
        [Column("comment")]
        public string Comment { get; set; }
    }
}
