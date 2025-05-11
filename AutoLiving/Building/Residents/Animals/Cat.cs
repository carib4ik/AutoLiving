using AutoLiving.Interfaces;

namespace AutoLiving.Building.Residents.Animals;

public class Cat : Animal
{
    public Cat(string name, int animalFood) : base(name, animalFood)
    {
        Name = name;
        AnimalFood = animalFood;
    }

    public override void Say()
    {
        Stamina -= 2;
        Hungry -= 3;

        Console.WriteLine($"Pet {Name} is meewed!");
    }
}