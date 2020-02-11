using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Redesign;

namespace ECS.Redesign.Test
{
    public class Test
    {
        private Redesign.ECS _ESC;
        public void Setup()
        {
            _ESC = new Redesign.ECS(28, new TempSensor_Test(), new Heater_Test());
        }

        public static void Main()
        {
        }

        public class TempSensor_Test : Redesign.TempSensor
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

        public class Heater_Test : Redesign.Heater
        {
            public void TurnOn()
            {
                System.Console.WriteLine("Heater is on");
            }

            public void TurnOff()
            {
                System.Console.WriteLine("Heater is off");
            }

            public bool RunSelfTest()
            {
                return true;
            }
        }
    }
}
