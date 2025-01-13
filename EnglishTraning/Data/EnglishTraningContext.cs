using EnglishTraning.Models;
using Microsoft.EntityFrameworkCore;

namespace EnglishTraning.Data
{
    public class EnglishTraningContext : DbContext
    {
        public EnglishTraningContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<EnglishTense> EnglishTenses { get; set; }

    }
}
