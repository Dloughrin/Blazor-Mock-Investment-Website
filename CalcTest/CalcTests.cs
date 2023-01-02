using Investment_Calc.Data.Models;
using System.Diagnostics.Metrics;

namespace CalcTest
{
    [TestClass]
    public class CalcTests
    {
        //InvestmentCalc
        [TestMethod]
        public void TestDefault_Value()
        {
            InvestmentCalc calc = new InvestmentCalc();
            double fv = 1.01;
            Assert.AreEqual(calc.FutureValue, fv);
        }

        [TestMethod]
        public void TestMax_Value()
        {
            InvestmentCalc calc = new InvestmentCalc(24, 30, 100, 1000, 0);
            // Have to calculate here or rounding error
            double fv = (1000 * Math.Pow(1.0416666666666667, 720));
            Assert.AreEqual(calc.FutureValue, fv);
        }

        [TestMethod]
        public void TestGiven_Value()
        {
            InvestmentCalc calc = new InvestmentCalc(6, 5, 5, 320.33, 0);
            // Have to calculate here or rounding error
            double fv = (320.33 * Math.Pow(1.0083333333333333, 30));
            Assert.AreEqual(calc.FutureValue, fv);
        }

        [TestMethod]
        public void Test_OutOfRange()
        {
            // Check every variable for exception throwing

            try
            {
                InvestmentCalc calc = new InvestmentCalc(5, 5, 5, -5, 0);
                Assert.IsTrue(false);
            }
            catch (ArgumentOutOfRangeException e)
            {
                try
                {
                    InvestmentCalc calc = new InvestmentCalc(5, 5, -5, 5, 0);
                    Assert.IsTrue(false);
                }
                catch (ArgumentOutOfRangeException ec)
                {
                    try
                    {
                        InvestmentCalc calc = new InvestmentCalc(5, -5, 5, 5, 0);
                        Assert.IsTrue(false);
                    }
                    catch (ArgumentOutOfRangeException eb)
                    {
                        try
                        {
                            InvestmentCalc calc = new InvestmentCalc(-5, 5, 5, 5, 0);
                            Assert.IsTrue(false);
                        }
                        catch (ArgumentOutOfRangeException ea)
                        {
                            Assert.IsTrue(true);
                        }
                    }
                }
            }
        }

        //Asset
        [TestMethod]
        public void Test_DefaultConstructor()
        {
            Asset asset = new Asset();
            Assert.AreEqual(asset.CurrentValue, 0);
        }

        [TestMethod]
        public void Test_Constructor()
        {
            DateTime start = new DateTime(2020,11,1,6,0,0);
            DateTime end = new DateTime(2022, 11, 1, 6, 0, 0);
            //1M starting value, 200k salvage value, 10 year expiration
            Asset asset = new Asset(1000000, 200000, 10, start, end);
            //800k/10 => 80k per year, 1M - 160k => 840k
            Assert.AreEqual(asset.CurrentValue, 840000);
        }

        [TestMethod]
        public void Test_MaxValue()
        {
            DateTime start = new DateTime(2012, 11, 1, 6, 0, 0);
            DateTime end = new DateTime(2022, 11, 1, 6, 0, 0);
            //1M starting value, 200k salvage value, 5 year expiration
            Asset asset = new Asset(1000000, 200000, 5, start, end);
            //Should be at salvage value
            Assert.AreEqual(asset.CurrentValue, 200000);
        }

        [TestMethod]
        public void Test_OutOfRange_Asset()
        {
            // Check every variable for exception throwing

            try
            {
                DateTime start = new DateTime(2012, 11, 1, 6, 0, 0);
                DateTime end = new DateTime(2022, 11, 1, 6, 0, 0);
                Asset asset = new Asset(-1, 200, 5, start, end);
                Assert.IsTrue(false);
            }
            catch (ArgumentOutOfRangeException e)
            {
                try
                {
                    DateTime start = new DateTime(2012, 11, 1, 6, 0, 0);
                    DateTime end = new DateTime(2022, 11, 1, 6, 0, 0);
                    Asset asset = new Asset(1000, -1, 5, start, end);
                    Assert.IsTrue(false);
                }
                catch (ArgumentOutOfRangeException ec)
                {
                    try
                    {
                        DateTime start = new DateTime(2012, 11, 1, 6, 0, 0);
                        DateTime end = new DateTime(2022, 11, 1, 6, 0, 0);
                        Asset asset = new Asset(1000, 200, 0, start, end);
                        Assert.IsTrue(false);
                    }
                    catch (ArgumentOutOfRangeException eb)
                    {
                        try
                        {
                            DateTime start = new DateTime(2031, 11, 1, 6, 0, 0);
                            DateTime end = new DateTime(2032, 11, 1, 6, 0, 0);
                            Asset asset = new Asset(1000, 200, 5, start, end);
                            Assert.IsTrue(false);
                        }
                        catch (ArgumentOutOfRangeException ea)
                        {
                            try
                            {
                                DateTime start = new DateTime(2022, 11, 1, 6, 0, 0);
                                DateTime end = new DateTime(2012, 11, 1, 6, 0, 0);
                                Asset asset = new Asset(1000, 200, 5, start, end);
                                Assert.IsTrue(false);
                            }
                            catch (ArgumentOutOfRangeException eaa)
                            {
                                Assert.IsTrue(true);
                            }
                        }
                    }
                }
            }
        }
    }
}