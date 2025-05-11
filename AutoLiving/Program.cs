using AutoLiving.Controllers;

namespace AutoLiving;

public static class Program
{
    public static void Main()
    {
        var building = new Building.Building();
        var buildingController = new BuildingController(building);

        while (true)
        {
            buildingController.Live();
            Thread.Sleep(1000);

            Console.WriteLine("----------********----------");
        }
    }
}