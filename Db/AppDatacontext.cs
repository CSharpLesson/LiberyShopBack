using LiberyShop.Interface;
using Microsoft.EntityFrameworkCore;
using LiberyShop.Model;

namespace LiberyShop.Db
{
    public class AppDatacontext : DbContext, IDataContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public AppDatacontext(DbContextOptions<AppDatacontext> options) : base(options)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Recipient> Recipients { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<BookSort> BookSorts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DbContext IDataContext.DataContext { get { return this; } }
    }

}
