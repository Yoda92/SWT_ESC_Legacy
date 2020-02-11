namespace ECS.Redesign
{
    public class ECS
    {
        private int _threshold;
        private readonly TempSensor _tempSensor;
        private readonly Heater _heater;

        // Constructor injection
        public ECS(int thr, TempSensor thisTempSensor, Heater thisHeater)
        {
            SetThreshold(thr);
            _tempSensor = thisTempSensor;
            _heater = thisHeater;
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            if (t < _threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();

        }

        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}
