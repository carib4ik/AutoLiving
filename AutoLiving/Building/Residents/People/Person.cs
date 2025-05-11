using AutoLiving.Building.Residents.Animals;
using AutoLiving.Interfaces;

namespace AutoLiving.Building.Residents.People;

public class Person : Resident, ILive
{
    public Animal Pet { get; } = null!;
    public int CurrentBudget { get; private set; }
    public int HumanFood { get; private set; }
    
    private int _salary { get; }

    public Person(string name, int salary, int currentBudget, int humanFood) : base(name)
    {
        _salary = salary;
        CurrentBudget = currentBudget;
        HumanFood = humanFood;
        Name = name;
    }
    
    public Person(string name, int salary, int currentBudget, int humanFood, Animal pet) : base(name)
    {
        _salary = salary;
        CurrentBudget = currentBudget;
        HumanFood = humanFood;
        Pet = pet;
        Name = name;

        Pet.AskFood += FeedPet;
    }
    
    public void Eat(int eatenFood)
    {
        HumanFood -= eatenFood;
        Hungry += eatenFood * 2;
        
        Console.WriteLine($"{Name} has eaten {eatenFood} food. [Hungry {Hungry}. Stamina {Stamina}. Human food {HumanFood}. Current budget {CurrentBudget}]");
    }

    public void Play(int playTime)
    {
        Stamina -= playTime;
        Hungry -= playTime * 2;
        
        Console.WriteLine($"{Name} has played {playTime} minutes. [Hungry {Hungry}. Stamina {Stamina}. Human food {HumanFood}. Current budget {CurrentBudget}]");
    }

    public void Work(int workTime)
    {
        CurrentBudget += _salary;
        Stamina -= workTime;
        Hungry -= workTime * 2;
        
        Console.WriteLine($"{Name} has worked {workTime} minutes. [Hungry {Hungry}. Stamina {Stamina}. Human food {HumanFood}. Current budget {CurrentBudget}]");
    }

    public void Sleep()
    {
        Stamina = 100;
        Hungry -= 20;
        
        Console.WriteLine($"{Name} has slept. [Hungry {Hungry}. [Stamina {Stamina}. Human food {HumanFood}. Current budget {CurrentBudget}]");
    }

    public void BuyHumanFood(int bill, int foodQuantity)
    {
        HumanFood += foodQuantity;
        CurrentBudget -= bill;
        Stamina -= 20;
        Hungry -= 15;

        Console.WriteLine($"{Name} has bought {foodQuantity} food for {bill}$. [Hungry {Hungry}. Stamina {Stamina}. Human food {HumanFood}. Current budget {CurrentBudget}]");
    }

    private int FeedPet()
    {
        Stamina -= 3;
        Hungry -= 2;

        var foodQuantity = new Random().Next(5, 15);
        

        if (Pet.AnimalFood <= 0)
        {
            BuyAnimalFood(new Random().Next(10, 20), new Random().Next(20, 40));
        }
        else if (foodQuantity > Pet.AnimalFood)
        {
            foodQuantity = Pet.AnimalFood;
        }
        
        Console.WriteLine($"{Name} feed a pet {Pet.Name}");

        return foodQuantity;
    }

    private void BuyAnimalFood(int bill, int foodQuantity)
    {
        Pet.AnimalFood += foodQuantity;
        CurrentBudget -= bill;
        Stamina -= 20;
        Hungry -= 15;
        
        Console.WriteLine($"{Name} has bought {foodQuantity} animal food for {bill}$. [Hungry {Hungry}. Stamina {Stamina}. Animal food {Pet.AnimalFood}. Current budget {CurrentBudget}]");
    }
}