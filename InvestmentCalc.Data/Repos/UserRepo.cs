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
    public class UserRepo : I_UserRepo
    {
        private IDbContextFactory<InvestCalcContext> factory;

        public UserRepo(IDbContextFactory<InvestCalcContext> factory)
        {
            this.factory = factory;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            using var context = factory.CreateDbContext();
            return await context.Users.ToListAsync();
        }

        public async Task<User?> GetUserAsync(int id)
        {
            using var context = factory.CreateDbContext();
            return await context.Users.Where(i => i.Id == id).FirstOrDefaultAsync();
        }


        public async Task<User> SaveUserAsync(User user)
        {
            using var context = factory.CreateDbContext();
            if (user.Id == 0) //Add new item
            {
                context.Users.Add(user);
            }
            else //Update old item
            {
                context.Entry(user).State = EntityState.Modified;
            }
            await context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserAsync(User item)
        {
            using var context = factory.CreateDbContext();
            context.Remove(item);
            await context.SaveChangesAsync();
        }
    }
}
