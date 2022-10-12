using CarConditionCheck;
namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAveregeMilliage()
        {
            CheckCar[] checks = new CheckCar[5];
            checks[0] = new CheckCar(2015,1,1,0,1,10);
            checks[1] = new CheckCar(2016, 1, 1, 20, 1, 5);
            checks[2] = new CheckCar(2017, 1, 1, 40, 1, 10);
            checks[3] = new CheckCar(2018, 1, 1, 60, 1, 5);
            Assert.AreEqual(20, CheckCar.GetAveregeMilliage(checks));
        }

        [TestMethod]
        public void TesttMilliageByPeriod()
        {
            CheckCar[] checks = new CheckCar[5];
            checks[0] = new CheckCar(2015, 1, 1, 0, 1, 10);
            checks[1] = new CheckCar(2016, 1, 1, 20, 1, 5);
            checks[2] = new CheckCar(2017, 1, 1, 40, 1, 10);
            checks[3] = new CheckCar(2018, 1, 1, 60, 1, 5);
            Assert.AreEqual(20, CheckCar.GetMilliageByPeriod(2015, 2016, checks));
        }

        [TestMethod]
        public void TestAvgChecks()
        {
            CheckCar[] checks = new CheckCar[5];
            checks[0] = new CheckCar(2015, 1, 1, 14, 1, 10);
            checks[1] = new CheckCar(2016, 1, 1, 20, 0, 5);
            Assert.AreEqual($"Checks by water level - 0\n" +
                $"Checks by oil level - 1\n" +
                $"Checks by tire pressure - 2", CheckCar.GetAvgChecks(checks, 2015, 2016));
        }
    }
}