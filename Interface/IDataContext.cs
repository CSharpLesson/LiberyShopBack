using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiberyShop.Interface
{
    public interface IDataContext
    {
        DbContext DataContext { get; }
    }
}
