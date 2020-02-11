using System;

namespace ECS.Redesign
{
    public interface TempSensor
    {
        int GetTemp();
        bool RunSelfTest();
    }
    public class TempSensor_imp : TempSensor
    {
        private Random gen = new Random();

        public int GetTemp()
        {
            return gen.Next(-5, 45);
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}