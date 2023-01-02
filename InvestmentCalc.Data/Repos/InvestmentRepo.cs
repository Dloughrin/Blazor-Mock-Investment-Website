using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Investment_Calc.Data.Interfaces;
using Investment_Calc.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Investment_Calc.Data.Repos
{
    public class InvestmentRepo : I_InvestmentRepo
    {
        private IDbContextFactory<InvestCalcContext> factory;

        public InvestmentRepo(IDbContextFactory<InvestCalcContext> factory)
        {
            this.factory = factory;
        }

        public async Task<List<InvestmentCalc>> GetInvestmentsAsync()
        {
            using var context = factory.CreateDbContext();
            return await context.Investments.ToListAsync();
        }

        public async Task<List<InvestmentCalc>> GetUserInvestmentsAsync(User u)
        {
            using var context = factory.CreateDbContext();
            return await context.Investments.Where(i => i.User_ID == u.Id).ToListAsync();
        }

        public async Task<InvestmentCalc?> GetInvestmentAsync(int id)
        {
            using var context = factory.CreateDbContext();
            return await context.Investments.Where(i => i.Id == id).FirstOrDefaultAsync();
        }


        public async Task<InvestmentCalc> SaveInvestmentAsync(InvestmentCalc item)
        {
            using var context = factory.CreateDbContext();
            if (item.Id == 0) //Add new item
            {
                context.Investments.Add(item);
            }
            else //Update old item
            {
                context.Entry(item).State = EntityState.Modified;
            }
            await context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteInvestmentAsync(InvestmentCalc item)
        {
            using var context = factory.CreateDbContext();
            context.Remove(item);
            await context.SaveChangesAsync();
        }
    }
}
