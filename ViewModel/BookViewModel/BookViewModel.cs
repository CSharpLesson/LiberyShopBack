using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiberyShop.ViewModel.BookViewModel
{
    public class BookViewModel
    {

        /// <summary>
        /// book name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// book author
        /// </summary>
        public int AuthorId { get; set; }
        /// <summary>
        /// forinkey
        /// </summary>
        public string  AuthorName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BookUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PhotoUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public  string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? BookSort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public  string BookSortName { get; set; }
    }
}
