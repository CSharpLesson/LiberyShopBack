using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LiberyShop.Interface;
using LiberyShop.Model;
using LiberyShop.ViewModel.UserViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiberyShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private IUser _user;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public LoginController(IUser user)
        {
            _user = user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            (User result, Exception error) = _user.GetById(id);

            return error == null ? Ok(result) : Ok(error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>        
        [HttpGet]
        public async Task<IActionResult> Enter(string login, string password)
        {
            (bool result, int user_id, Exception error) = _user.Enter(login, password);

            return error == null ? Ok(new { result, user_id }) : Ok(new {result=false, user_id=0});
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<User>> GetAll()
        {
            (List<User> result, Exception error) = _user.GetAll();
            return error == null ? result : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public void UserPost([FromBody] UserViewModel user)
        {
            _user.Insert(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        [HttpPut]
        public void UserPut([FromBody] UserPutViewModel user)
        {
            _user.Update(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public void UserDelete(int id)
        {
            _user.Delete(id);
        }
    }
}