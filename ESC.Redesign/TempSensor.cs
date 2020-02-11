﻿using System;

namespace ECS.Legacy
{
    public interface TempSensor
    {
        int GetTemp();
        bool RunSelfTest();
    }
    internal class TempSensor_imp : TempSensor
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