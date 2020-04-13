using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiberyShop.Interface;
using LiberyShop.ViewModel.BookSortViewModel;
using LiberyShop.ViewModel.BookViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiberyShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private IBookService _bookService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookService"></param>
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            (BookViewModel result, Exception error) = _bookService.GetById(Id);

            return error == null ? Ok(result) : Ok(error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(int skip, int sort = 0)
        {
            (List<BookViewModel> result, int count, Exception error) = sort == 0 ? _bookService.GetAll(skip ) : _bookService.GetAll(skip, sort);

            return error == null ? Ok(new { result, count }) : Ok(error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> Post(BookAddViewModel model)
        {
            _bookService.Insert(model);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<bool> Put(BookPutViewModel model)
        {
            _bookService.Update(model);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uploadedFile"></param>
        /// <returns></returns>
        [HttpPost]
        [RequestSizeLimit(214748364)]
        public async Task<bool> AddFile(IFormFile uploadedFile)
        {
            _bookService.Upload(uploadedFile);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uploadedFile"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> AddPhoto(IFormFile uploadedPhoto)
        {
            _bookService.UploadPhoto(uploadedPhoto);

            return true;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSort() 
        {
            (List<BookSortViewModel> result, Exception error) = _bookService.GetAllBookSort();

            return error == null ? Ok(result) : Ok(error);
        }
    }
}