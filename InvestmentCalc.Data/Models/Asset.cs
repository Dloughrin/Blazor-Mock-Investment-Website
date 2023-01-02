using Investment_Calc.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Investment_Calc.Data.Models
{
    public class Asset : I_Asset
    {
        private double _start_value;
        private double _salvage_value;

        private TimeSpan _expiration;
        private DateTime _enter_date;
        private DateTime? _exit_date;

        public int Id { get; set; }
        public double? CurrentValue { get; private set; }
        public double? Depreciation { get; private set; }

        public double StartValue
        {
            get
            {
                return _start_value;
            }
            set
            {
                if(value >= 0)
                {
                    _start_value = value;
                    Calc();
                }
                else
                {
                    // Throws a nice error message telling the user which variable has an issue
                    throw new ArgumentOutOfRangeException("Start Value");
                }
            }
        }
        public double SalvageValue
        {
            get
            {
                return _salvage_value;
            }
            set
            {
                if (value >= 0)
                {
                    _salvage_value = value;
                    Calc();
                }
                else
                {
                    // Throws a nice error message telling the user which variable has an issue
                    throw new ArgumentOutOfRangeException("Salvage Value");
                }
            }
        }

        //double to make calculations using it less weird
        public double Expiration
        {
            get
            {
                return Math.Floor(_expiration.TotalDays/365);
            }
            set
            {
                if(value >= 1)
                {
                    _expiration = new TimeSpan((365 * (int)value), 6 * (int)value, 0, 0);
                    Calc();
                }
                else
                {
                    // Throws a nice error message telling the user which variable has an issue
                    throw new ArgumentOutOfRangeException("Years to Expiration");
                }
            }
        }

        public DateTime EnterDate
        {
            get
            {
                return _enter_date;
            }
            set
            {
                if(value <= DateTime.Today) { 
                    _enter_date = value;
                    Calc();
                }
                else
                {
                    // Throws a nice error message telling the user which variable has an issue
                    throw new ArgumentOutOfRangeException("Entered Date");
                }
            }
        }

        public DateTime? LeaveDate
        {
            get
            {
                if(_exit_date == null)
                {
                    return null;
                }
                else
                {
                    return (DateTime)_exit_date;
                }
            }
            set
            {
                if(value == null || value >= EnterDate) { 
                    _exit_date = value;
                    Calc();
                }
                else
                {
                    // Throws a nice error message telling the user which variable has an issue
                    throw new ArgumentOutOfRangeException("Exit Date");
                }
            }
        }
        public void Calc()
        {
            Depreciation = (StartValue - SalvageValue) / Expiration;
            TimeSpan temp;
            if (LeaveDate != null)
            {
                temp = (TimeSpan)(LeaveDate - EnterDate);
            }
            else
            {
                temp = DateTime.Today - EnterDate;
            }
            CurrentValue = Math.Max((double)(StartValue - Depreciation*Math.Floor(temp.TotalDays / 365)), Math.Min(StartValue,SalvageValue));
        }
        public double Calc(DateTime year)
        {
            TimeSpan temp;
            if (LeaveDate != null && LeaveDate < year)
            {
                temp = (TimeSpan)(LeaveDate - EnterDate);
            }
            else
            {
                temp = (TimeSpan)(year - EnterDate);
            }
            return Math.Max((double)(StartValue - Depreciation * Math.Floor(temp.TotalDays / 365)), SalvageValue);
        }

        public Asset()
        {
            StartValue = 0.0;
            SalvageValue = 0.0;
            // 1 -> 1 year
            Expiration = 1;
            EnterDate = new DateTime();
            LeaveDate = null;
        }

        public Asset(double start, double salv, int exp, DateTime enter, DateTime? leave)
        {
            StartValue = start;
            SalvageValue = salv;
            Expiration = exp;
            EnterDate = enter;
            LeaveDate = leave;
        }
    }
}
