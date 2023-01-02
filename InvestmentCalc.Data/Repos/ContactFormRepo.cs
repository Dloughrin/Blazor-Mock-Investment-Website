using Investment_Calc.Data.Interfaces;
using Investment_Calc.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investment_Calc.Data.Repos
{
    public class ContactFormRepo : I_ContactFormRepo
    {
        private IDbContextFactory<InvestCalcContext> factory;

        public ContactFormRepo(IDbContextFactory<InvestCalcContext> factory)
        {
            this.factory = factory;
        }

        public async Task<List<ContactForm>> GetCFsAsync()
        {
            using var context = factory.CreateDbContext();
            return await context.Forms.ToListAsync();
        }

        public async Task<List<ContactForm>> GetCFsNotResolvedAsync()
        {
            using var context = factory.CreateDbContext();
            return await context.Forms.Where(i => i.isResolved == false).ToListAsync();
        }

        public async Task<ContactForm?> GetCFAsync(int id)
        {
            using var context = factory.CreateDbContext();
            return await context.Forms.Where(i => i.Id == id).FirstOrDefaultAsync();
        }


        public async Task<ContactForm> SaveCFAsync(ContactForm item)
        {
            using var context = factory.CreateDbContext();
            if (item.Id == 0) //Add new item
            {
                context.Forms.Add(item);
            }
            else //Update old item
            {
                context.Entry(item).State = EntityState.Modified;
            }
            await context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteCFAsync(ContactForm item)
        {
            using var context = factory.CreateDbContext();
            context.Remove(item);
            await context.SaveChangesAsync();
        }
    }
}
