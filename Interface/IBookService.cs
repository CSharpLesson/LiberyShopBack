using LiberyShop.Db;
using LiberyShop.ViewModel.BookSortViewModel;
using LiberyShop.ViewModel.BookViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiberyShop.Interface
{
    public interface IBookService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        (List<BookViewModel>, int, Exception) GetAll(int skip);

        (List<BookViewModel>, int, Exception) GetAll(int skip,int sort);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        (BookViewModel, Exception) GetById(int Id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        void Insert(BookAddViewModel user);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        void Update(BookPutViewModel user);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        void Delete(int Id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        void Upload(IFormFile file);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        void UploadPhoto(IFormFile file);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        (List<BookSortViewModel>, Exception) GetAllBookSort();
    }
}
