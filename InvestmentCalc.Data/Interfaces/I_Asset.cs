using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Investment_Calc.Data.Interfaces
{
    internal interface I_Asset
    {
        public int Id { get; set; }
    }
}
