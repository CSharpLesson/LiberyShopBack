using LiberyShop.Model;
using LiberyShop.ViewModel.AuthorViewModel;
using LiberyShop.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiberyShop.Interface
{
    public interface IAuthorService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        (List<Author>, Exception) GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        (Author, Exception) GetById(int Id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        void Insert(AuthorViewModel user);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        void Update(AuthorPutViewModel user);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        void Delete(int Id);        
    }
}
