namespace EkvipProgrammingTask;

public class SimpleCalculator
{
    private int _value;
    private readonly Random _random = new Random();

    public int Value
    {
        get => _value;
        set => _value = value;
    }

    public void Increment()
    {
        _value += 1; // or value++
    }

    public void Decrement()
    {
        _value -= 1; // or value--
    }

    public void Double()
    {
        _value *= 2;
    }

    public void AddRandomValue()
    {
        _value += _random.Next();
    }
}