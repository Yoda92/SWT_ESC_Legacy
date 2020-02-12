using ECS.Redesign;
using NUnit.Framework;

namespace ESC.Redesign.Test
{
    public class Test
    {
        private ECS.Redesign.ECS _ESC;
        private HeaterTest ThisHeaterTest;
        private TempSensorTest ThisTempSensorTest;
        private int ThisThreshold;

        [SetUp]
        public void Setup()
        {
            ThisThreshold = 28;
            ThisTempSensorTest = new TempSensorTest();
            ThisHeaterTest = new HeaterTest();
            _ESC = new ECS.Redesign.ECS(ThisThreshold, ThisTempSensorTest, ThisHeaterTest);
        }

        // Testing the ECS class
        // Testing threshold
        [TestCase(28)]
        [TestCase(35)]
        [TestCase(30)]
        public void TestThreshold(int someThreshold)
        {
            _ESC.SetThreshold(someThreshold);
            Assert.That(_ESC.GetThreshold(), Is.EqualTo(someThreshold).Within(0.05));
        }

        // Testing regulate
        [TestCase(25, 30, true)]
        [TestCase(35, 30, false)]
        [TestCase(30, 30, false)]
        public void TestRegulate(int testTemp, int testThreshold, bool testIsHeaterOn)
        {
            ThisTempSensorTest.Temp = testTemp;
            _ESC.SetThreshold(testThreshold);
            _ESC.Regulate();
            Assert.That(ThisHeaterTest.IsHeaterOn, Is.EqualTo(testIsHeaterOn));
        }

        // Testing GetCurTemp
        [TestCase(10)]
        [TestCase(30)]
        [TestCase(37)]
        public void TestGetCurTemp(int testTemp)
        {
            ThisTempSensorTest.Temp = testTemp;
            Assert.That(_ESC.GetCurTemp(), Is.EqualTo(testTemp).Within(0.05));
        }

        // Testing GetCurTemp
        [TestCase(ExpectedResult = true)]
        [TestCase(ExpectedResult = true)]
        [TestCase(ExpectedResult = true)]
        public bool RunSelfTest()
        {
            bool result = _ESC.RunSelfTest();
            return result;
        }

        public class TempSensorTest : TempSensor
        {
            public int Temp { get; set; }
            public int GetTemp()
            {
                return Temp;
            }

            public bool RunSelfTest()
            {
                return true;
            }
        }

        public class HeaterTest : Heater
        {
            public bool IsHeaterOn;
            public void TurnOn()
            {
                IsHeaterOn = true;
            }

            public void TurnOff()
            {
                IsHeaterOn = false;
            }

            public bool RunSelfTest()
            {
                return true;
            }
        }
    }
}
