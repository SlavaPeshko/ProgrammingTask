namespace EkvipProgrammingTask.Commands;

public class Increment : Command
{
    private readonly SimpleCalculator _calculator;
    private readonly int _previousValue;

    public Increment(SimpleCalculator calculator) : base(calculator)
    {
        _calculator = calculator;
        _previousValue = calculator.Value;
    }

    public override void Execute()
    {
        _calculator.Increment();
    }

    public override void Undo()
    {
        _calculator.Value = _previousValue;
    }
}