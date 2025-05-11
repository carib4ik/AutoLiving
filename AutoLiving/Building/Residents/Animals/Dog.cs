namespace AutoLiving.Building.Residents.Animals;

public class Dog : Animal
{
    public Dog(string name, int animalFood) : base(name, animalFood)
    {
        Name = name;
        AnimalFood = animalFood;
    }

    public override void Say()
    {
        Stamina -= 3;
        Hungry -= 4;

        Console.WriteLine($"Pet {Name} is barking!");
    }
}