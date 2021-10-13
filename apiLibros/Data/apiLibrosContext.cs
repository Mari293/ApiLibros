using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apiLibros.Models;

namespace apiLibros.Data
{
    public class apiLibrosContext : DbContext
    {
        public apiLibrosContext (DbContextOptions<apiLibrosContext> options)
            : base(options)
        {
        }

        public DbSet<apiLibros.Models.book> book { get; set; }
    }
}
