namespace ECS.Legacy
{
    public class Application
    {
        public static void Main(string[] args)
        {
            // Constructor injection
            var ecs = new ECS(28, new TempSensor_imp(), new Heater_imp());

            ecs.Regulate();

            ecs.SetThreshold(20);

            ecs.Regulate();
        }
    }
}
