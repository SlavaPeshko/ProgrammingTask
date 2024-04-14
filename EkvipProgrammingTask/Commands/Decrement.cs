namespace EkvipProgrammingTask.Commands;

public class Decrement : Command
{
    private readonly SimpleCalculator _calculator;
    private readonly int _previousValue;

    public Decrement(SimpleCalculator calculator) : base(calculator)
    {
        _calculator = calculator;
        _previousValue = calculator.Value;
    }

    public override void Execute()
    {
        _calculator.Decrement();
    }

    public override void Undo()
    {
        _calculator.Value = _previousValue;
    }
}