using LiberyShop.Db;
using LiberyShop.Interface;
using LiberyShop.Model;
using LiberyShop.ViewModel.BookSortViewModel;
using LiberyShop.ViewModel.BookViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LiberyShop.Services
{
    public class BookService : IBookService
    {
        static string BookUrl;
        static string PhotoUrl;
        private AppDatacontext _context;

        public BookService(AppDatacontext context)
        {
            _context = context;
        }

        public void Delete(int Id)
        {
            _context.Remove(_context.Books.FirstOrDefault(f => f.Id == Id));
            _context.SaveChanges();

        }

        public (List<BookViewModel>, int, Exception) GetAll(int skip)
        {
            try
            {

                var entity = _context.Books.Include(f => f.AuthorModel)
                                           .Select(s => new BookViewModel
                                           {
                                               Name = s.Name,
                                               AuthorId = s.AuthorId,
                                               AuthorName = s.AuthorModel != null ? s.AuthorModel.AuthorName : string.Empty,
                                               BookUrl = s.BookUrl,
                                               PhotoUrl = s.PhotoUrl,
                                               BookSort = s.BookSort,
                                               BookSortName = s.BookSortModel != null ? s.BookSortModel.Name : string.Empty,
                                               UserId = s.UserId,
                                               UserName = s.UserModel.Login

                                           }).Skip(skip * 3).Take(3).ToList();

                return (entity, entity.Count, null);
            }
            catch (Exception ex)
            {
                return (null, 0, ex);
            }
        }
        public (List<BookViewModel>, int, Exception) GetAll(int skip,  int sort)
        {
            try
            {

                var entity = _context.Books.Where(f => f.BookSort == sort).Include(i => i.AuthorModel)
                                           .Select(s => new BookViewModel
                                           {
                                               Name = s.Name,
                                               AuthorId = s.AuthorId,
                                               AuthorName = s.AuthorModel != null ? s.AuthorModel.AuthorName : string.Empty,
                                               BookUrl = s.BookUrl,
                                               PhotoUrl = s.PhotoUrl,
                                               BookSort = s.BookSort,
                                               BookSortName = s.BookSortModel != null ? s.BookSortModel.Name : string.Empty,
                                               UserId = s.UserId

                                           }).Skip(skip * 3).Take(3).ToList();

                return (entity, entity.Count, null);
            }
            catch (Exception ex)
            {
                return (null, 0, ex);
            }
        }

        public (List<BookSortViewModel>, Exception) GetAllBookSort()
        {
            try
            {
                var entity = _context.BookSorts.Select(s => new BookSortViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList();
                return (entity, null);
            }
            catch (Exception ex)
            {

                return (null, ex);
            }
        }

        public (BookViewModel, Exception) GetById(int Id)
        {
            try
            {
                var entity = _context.Books.Include(f => f.AuthorModel)
                                           .Select(s => new BookViewModel
                                           {
                                               Name = s.Name,
                                               AuthorId = s.AuthorId,
                                               AuthorName = s.AuthorModel != null ? s.AuthorModel.AuthorName : string.Empty,
                                               BookUrl = s.BookUrl,
                                               PhotoUrl = s.PhotoUrl,
                                               BookSort = s.BookSort.Value,
                                               BookSortName = s.BookSortModel != null ? s.BookSortModel.Name : string.Empty,
                                               UserId = s.UserId.Value

                                           }).FirstOrDefault();

                return (entity, null);
            }
            catch (Exception ex)
            {
                return (null, ex);
            }
        }

        public void Insert(BookAddViewModel user)
        {
            Book book = new Book();
            book.Name = user.Name;
            book.AuthorId = user.AuthorId;
            book.BookUrl = BookUrl == null ? user.BookUrl : BookUrl;
            book.PhotoUrl = PhotoUrl == null ? user.PhotoUrl : PhotoUrl;

            _context.Books.Add(book);
            _context.SaveChanges();
            BookUrl = null;
            PhotoUrl = null;
        }

        public void Update(BookPutViewModel user)
        {
            var book = _context.Books.FirstOrDefault(f => f.Id == user.Id);
            book.Name = user.Name;
            book.AuthorId = user.AuthorId;
            book.BookUrl = BookUrl == null ? book.BookUrl : BookUrl;
            book.PhotoUrl = PhotoUrl == null ? user.PhotoUrl : PhotoUrl;

            _context.Update(book);
            _context.SaveChanges();

            BookUrl = null;
            PhotoUrl = null;
        }

        public void Upload(IFormFile file)
        {
            if (file != null)
            {
                // путь к папке Files
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Books", ChangePdf(file.FileName));
                // сохраняем файл в папку Files в каталоге wwwroot
                var bytes = new byte[file.Length];
                file.OpenReadStream().Read(bytes, 0, bytes.Length);
                File.WriteAllBytes(path, bytes);
                path = "https://localhost:5001/Books/" + ChangePdf(file.FileName);

                BookUrl = path;
            }


        }
        public void UploadPhoto(IFormFile file)
        {
            if (file != null)
            {
                // путь к папке Files

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Photos", file.FileName);
                //string path = "Front/LiberyShop/assets/image/"+ file.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                var bytes = new byte[file.Length];
                file.OpenReadStream().Read(bytes, 0, bytes.Length);
                File.WriteAllBytes(path, bytes);
                path = "https://localhost:5001/Photos/" + file.FileName;
                PhotoUrl = path;
            }
        }


        private string ChangePdf(string fileName)
        {
            try
            {
                return TryChangePdf(fileName);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        private string TryChangePdf(string fileName)
        {
            var id = _context.Books.Last().Id + 1;
            return id + ".pdf";
        }

    }
}
