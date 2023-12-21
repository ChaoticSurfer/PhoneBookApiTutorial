using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebApplication3
{
    public class PhoneBookDbContext : DbContext
    {
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options)
            : base(options)
        {
        }

        public DbSet<PhoneRecord> PhoneRecords { get; set; }
    }
}
