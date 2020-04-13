using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiberyShop.ViewModel.BookViewModel
{
    public class BookAddViewModel
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
        /// 
        /// </summary>
        public string BookUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PhotoUrl { get; set; }
    }
}
