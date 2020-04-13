using LiberyShop.Model;
using LiberyShop.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiberyShop.Interface
{
    public interface IUser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        (List<User>,Exception) GetAll();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        (User, Exception) GetById(int Id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        void Insert(UserViewModel user);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        void Update(UserPutViewModel user);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        void Delete(int Id);        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        (bool,int, Exception) Enter(string login, string password);
    }
}
