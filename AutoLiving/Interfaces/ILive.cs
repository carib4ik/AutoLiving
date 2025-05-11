namespace AutoLiving.Interfaces;

public interface ILive
{
    public void Eat(int eatenFood);

    public void Play(int playTime);
    
    public void Sleep();
}