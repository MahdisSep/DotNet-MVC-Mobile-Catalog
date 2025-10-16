using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcMobileContext : DbContext
    {
        public MvcMobileContext (DbContextOptions<MvcMobileContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Mobile> Mobile { get; set; } = default!;
    }
}
