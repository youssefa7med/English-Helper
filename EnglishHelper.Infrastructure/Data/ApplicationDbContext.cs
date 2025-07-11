using EnglishHelper.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EnglishHelper.Data
{
    public class ApplicationDbContext : DbContext
    {
      
        public ApplicationDbContext(DbContextOptions options) :base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
