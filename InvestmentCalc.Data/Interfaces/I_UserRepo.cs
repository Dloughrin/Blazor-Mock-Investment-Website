using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Investment_Calc.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Investment_Calc.Data.Interfaces
{
    public interface I_UserRepo
    {
        Task<List<User>> GetUsersAsync();

        Task<User?> GetUserAsync(int id);

        Task<User> SaveUserAsync(User item);

        Task DeleteUserAsync(User item);
    }
}
