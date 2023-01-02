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
    public class AssetRepo : I_AssetRepo
    {
        private IDbContextFactory<InvestCalcContext> factory;

        public AssetRepo(IDbContextFactory<InvestCalcContext> factory)
        {
            this.factory = factory;
        }

        public async Task<List<Asset>> GetAssetsAsync()
        {
            using var context = factory.CreateDbContext();
            return await context.Assets.ToListAsync();
        }

        public async Task<Asset?> GetAssetAsync(int id)
        {
            using var context = factory.CreateDbContext();
            return await context.Assets.Where(i => i.Id == id).FirstOrDefaultAsync();
        }


        public async Task<Asset> SaveAssetAsync(Asset item)
        {
            using var context = factory.CreateDbContext();
            if (item.Id == 0) //Add new item
            {
                context.Assets.Add(item);
            }
            else //Update old item
            {
                context.Entry(item).State = EntityState.Modified;
            }
            await context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAssetAsync(Asset item)
        {
            using var context = factory.CreateDbContext();
            context.Remove(item);
            await context.SaveChangesAsync();
        }
    }
}
