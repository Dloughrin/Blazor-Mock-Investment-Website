using Investment_Calc.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Investment_Calc.Data.Models
{
    public class InvestmentCalc : I_InvestmentCalc
    {
        private int _cmpPerYr;
        private int _years;
        private double _interest;
        private double _principle;

        public int Id { get; set; }
        public int User_ID { get; set; }

        public int CmpPerYr
        {
            get
            {
                return _cmpPerYr;
            }
            set
            {
                if (value >= 1 && value <= 24)
                {
                    _cmpPerYr = value;
                    Calc();
                }
                else
                {
                    // Throws a nice error message telling the user which variable has an issue
                    throw new ArgumentOutOfRangeException("Compounds Per Year");
                }
            }
        }
        public int Years
        {
            get
            {
                return _years;
            }
            set
            {
                if (value >= 1 && value <= 30)
                {
                    _years = value;
                    Calc();
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Years");
                }
            }
        }
        public double Interest
        {
            get
            {
                return _interest;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _interest = value / 100;
                    Calc();
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Interest");
                }
            }
        }
        public double Principle
        {
            get
            {
                return _principle;
            }
            set
            {
                if (value > 0 && value < double.MaxValue)
                {
                    _principle = value;
                    Calc();
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Principle");
                }
            }
        }
        public double? FutureValue { get; private set; }

        public void Calc()
        {
            FutureValue = Principle * Math.Pow(1 + Interest / CmpPerYr, CmpPerYr * Years);
        }
        public double Calc(int nyear)
        {
            if(nyear > Years)
            {
                nyear = Years;
            }
            return Principle * Math.Pow(1 + Interest / CmpPerYr, CmpPerYr * nyear);
        }

        public InvestmentCalc(int cmpPerYr, int years, double interest, double principle, int uid)
        {
            Id = 0;
            CmpPerYr = cmpPerYr;
            Years = years;
            Interest = interest;
            Principle = principle;
            User_ID = uid;
            Calc();
        }

        public InvestmentCalc()
        {
            Id = 0;
            CmpPerYr = 1;
            Years = 1;
            Interest = 1;
            Principle = 1;
            User_ID = 1;
            Calc();
        }
    }
}
