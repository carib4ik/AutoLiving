using AutoLiving.Interfaces;

namespace AutoLiving.Building.Residents.Animals;

public class Animal : Resident, ILive
{
    public event Func<int>? AskFood;
    public int AnimalFood { get; set; }
    
    public Animal(string name, int animalFood) : base(name)
    {
        Name = name;
        AnimalFood = animalFood;
    }

    public void WantEat()
    {
        var food = AskFood!.Invoke();
        Eat(food);
    }
    
    public void Eat(int eatenFood)
    {
        AnimalFood -= eatenFood;
        Hungry += eatenFood * 2;
        
        Console.WriteLine($"Pet {Name} has eaten {eatenFood} food! [Hungry {Hungry}. Stamina {Stamina}. Animal food {AnimalFood}]");
    }

    public void Play(int playTime)
    {
        Stamina -= playTime;
        Hungry -= playTime * 2;
        
        Console.WriteLine($"Pet {Name} has played for {playTime} min. [Hungry {Hungry}. Stamina {Stamina}. Animal food {AnimalFood}]");
    }

    public void Sleep()
    {
        Stamina = 100;
        Hungry -= 15;
        
        Console.WriteLine($"Pet {Name} has slept. [Hungry {Hungry}. Stamina {Stamina}. Animal food {AnimalFood}]");
    }

    public virtual void Say()
    {
    }
}