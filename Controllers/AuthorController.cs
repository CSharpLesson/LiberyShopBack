using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiberyShop.Interface;
using LiberyShop.Model;
using LiberyShop.ViewModel.AuthorViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiberyShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IAuthorService _authorService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authorService"></param>
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            (List<Author> result, Exception error) = _authorService.GetAll();

            return error == null ? Ok(result) : Ok(error); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            (Author result, Exception error) = _authorService.GetById(Id);

            return error == null ? Ok(result) : Ok(error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> Post([FromBody] AuthorViewModel model)
        {
            _authorService.Insert(model);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<bool> Update([FromBody] AuthorPutViewModel model)
        {
            _authorService.Update(model);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<bool> Delete(int Id)
        {
            _authorService.Delete(Id);

            return true;
        }

    }
}