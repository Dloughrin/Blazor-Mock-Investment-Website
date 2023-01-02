using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Investment_Calc.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Investment_Calc.Data.Interfaces
{
    public interface I_InvestmentRepo
    {
        //Calc CRUD
        Task<List<InvestmentCalc>> GetInvestmentsAsync();

        Task<List<InvestmentCalc>> GetUserInvestmentsAsync(User u);

        Task<InvestmentCalc?> GetInvestmentAsync(int id);

        Task<InvestmentCalc> SaveInvestmentAsync(InvestmentCalc item);

        Task DeleteInvestmentAsync(InvestmentCalc item);
    }
}
