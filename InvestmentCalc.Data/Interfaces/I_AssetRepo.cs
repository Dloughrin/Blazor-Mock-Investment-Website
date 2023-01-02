using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Investment_Calc.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Investment_Calc.Data.Interfaces
{
    public interface I_AssetRepo
    {
        Task<List<Asset>> GetAssetsAsync();

        Task<Asset?> GetAssetAsync(int id);

        Task<Asset> SaveAssetAsync(Asset item);

        Task DeleteAssetAsync(Asset item);
    }
}
