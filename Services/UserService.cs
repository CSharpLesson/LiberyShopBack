using LiberyShop.Db;
using LiberyShop.Interface;
using LiberyShop.Model;
using LiberyShop.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiberyShop.Services
{
    public class UserService : IUser
    {
        /// <summary>
        /// 
        /// </summary>
        private AppDatacontext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UserService(AppDatacontext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void Delete(int Id)
        {
            var user = _context.Users.FirstOrDefault(f => f.Id == Id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public (bool, int, Exception) Enter(string login, string password)
        {
            try
            {
                var user = _context.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
                return (user == null ? false : true, user.Id, null);
            }
            catch (Exception ex)
            {
                return (false, 0, ex);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public (List<User>, Exception) GetAll()
        {
            try
            {
                return (_context.Users.ToList(), null);
            }
            catch (Exception ex)
            {
                return (null, ex);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public (User, Exception) GetById(int Id)
        {
            try
            {
                return (_context.Users.Where(x => x.Id == Id).FirstOrDefault(), null);
            }
            catch (Exception ex)
            {
                return (null, ex);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void Insert(UserViewModel user)
        {
            User user1 = new User();
            user1.Login = user.Login;
            user1.Password = user.Password;
            _context.Users.Add(user1);
            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void Update(UserPutViewModel user)
        {
            var user1 = _context.Users.FirstOrDefault(f => f.Id == user.Id);
            user1.Login = user.Login;
            user1.Password = user.Password;
            _context.Users.Update(user1);
            _context.SaveChanges();
        }
    }
}
