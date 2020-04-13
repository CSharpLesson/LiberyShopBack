using LiberyShop.Db;
using LiberyShop.Interface;
using LiberyShop.Model;
using LiberyShop.ViewModel.AuthorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiberyShop.Services
{
    public class AuthorService : IAuthorService
    {
        /// <summary>
        /// 
        /// </summary>
        private AppDatacontext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AuthorService(AppDatacontext context)
        {
            _context = context;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        public void Delete(int Id)
        {
            _context.Authors.Remove(_context.Authors.Where(f => f.Id == Id).FirstOrDefault());

            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public (List<Author>, Exception) GetAll()
        {
            try
            {
                var entity = _context.Authors.ToList();

                return (entity, null);
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
        public (Author, Exception) GetById(int Id)
        {
            try
            {
                return (_context.Authors.FirstOrDefault(f => f.Id == Id), null);
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
        public void Insert(AuthorViewModel user)
        {
            Author entity = new Author();
            entity.AuthorName = user.AuthorName;

            _context.Add(entity);

            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void Update(AuthorPutViewModel user)
        {
            var entity = _context.Authors.FirstOrDefault(f => f.Id == user.Id);
            entity.AuthorName = user.AuthorName;

            _context.Update(entity);

            _context.SaveChanges();
        }
    }
}
