using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Investment_Calc.Data.Models;

namespace Investment_Calc.Data
{
    public class InvestCalcContext : DbContext
    {
        public InvestCalcContext(DbContextOptions context) : base(context)
        {
        }

        public DbSet<InvestmentCalc> Investments { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ContactForm> Forms { get; set; }
    }

    public class InvestCalcContextFactory : IDesignTimeDbContextFactory<InvestCalcContext>
    {
        public InvestCalcContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InvestCalcContext>();
            optionsBuilder.UseSqlite("Data Source = ../Calc.db");
            return new InvestCalcContext(optionsBuilder.Options);
        }
    }
}
