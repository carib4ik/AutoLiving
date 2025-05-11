using AutoLiving.Building.Residents.People;

namespace AutoLiving.Controllers;

public class BuildingController
{
    private List<Person> _people;

    public BuildingController(Building.Building building)
    {
        _people = building.People;
    }

    public void Live()
    {
        foreach (var person in _people)
        {
            if (person.Hungry > 10 && person.Stamina > 10)
            {
                var playTime = new Random().Next(4, 21);
                person.Play(playTime);
            }

            else if (person.Stamina <= 10)
            {
                person.Sleep();
            }

            else if (person.Hungry <= 10 && person.HumanFood > 10)
            {
                var eatenFood = new Random().Next(10, 21);

                if (eatenFood > person.HumanFood)
                {
                    eatenFood = person.HumanFood;
                }
                
                person.Eat(eatenFood);
            }

            else if (person.HumanFood <= 10 && person.CurrentBudget >= 40)
            {
                var bill = new Random().Next(10, 41);
                var foodQuantity = new Random().Next(30, 61);
                person.BuyHumanFood(bill, foodQuantity);
            }

            else if (person.CurrentBudget < 40)
            {
                var workTime = new Random().Next(10, 40);
                person.Work(workTime);
            }

            //if person has a pet
            if (person.Pet != null)
            {
                if (person.Pet.Hungry > 10 && person.Pet.Stamina > 10)
                {
                    var playTime = new Random().Next(4, 21);
                    var say = new Random().Next(1, 4);
                    person.Pet.Play(playTime);
                    
                    for (int i = 0; i < say; i++)
                    {
                        person.Pet.Say();
                    }
                }
                else if (person.Pet.Stamina <= 10)
                {
                    person.Pet.Sleep();
                }
                else if (person.Pet.Hungry <= 10)
                {
                    person.Pet.WantEat();
                }
            }
        }
    }
}