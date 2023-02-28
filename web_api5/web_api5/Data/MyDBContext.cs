using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace web_api5.Data
{
    public class MyDBContext : DbContext
    {

        public MyDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Work> Works { get; set; }
    }
}
