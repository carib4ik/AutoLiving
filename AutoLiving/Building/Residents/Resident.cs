namespace AutoLiving.Building.Residents;

public abstract class Resident
{
    public string Name { get; protected init; }
    public int Stamina { get; protected set; }
    
    public int Hungry { get; protected set; }

    protected Resident(string name)
    {
        Name = name;
        Stamina = 100;
        Hungry = 100;
    }
}