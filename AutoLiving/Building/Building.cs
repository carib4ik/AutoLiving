using AutoLiving.Building.Residents.Animals;
using AutoLiving.Building.Residents.People;

namespace AutoLiving.Building;

public class Building
{
    public List<Person> People { get; }

    public Building()
    {
        People =
        [
            new Person("John", 30, 120, 80),
            new Person("Jane", 25, 75, 40, new Cat("Jerky", 30)),
            new Person("Jack", 45, 55, 10, new Cat("Bowl", 110)),
            new Person("Jill", 40, 320, 90),
            new Person("Paul", 10, 220, 180, new Dog("Pers", 65))
        ];
    }
}