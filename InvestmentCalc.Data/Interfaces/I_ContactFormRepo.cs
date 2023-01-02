using Investment_Calc.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investment_Calc.Data.Interfaces
{
    public interface I_ContactFormRepo
    {
        Task<List<ContactForm>> GetCFsAsync();

        Task<List<ContactForm>> GetCFsNotResolvedAsync();

        Task<ContactForm?> GetCFAsync(int id);

        Task<ContactForm> SaveCFAsync(ContactForm item);

        Task DeleteCFAsync(ContactForm item);
    }
}
