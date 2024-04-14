namespace EkvipProgrammingTask.Commands;

public class AddRandomValue : Command
{
    private readonly SimpleCalculator _calculator;
    private readonly int _previousValue;

    public AddRandomValue(SimpleCalculator calculator) : base(calculator)
    {
        _calculator = calculator;
        _previousValue = calculator.Value;
    }

    public override void Execute()
    {
        _calculator.AddRandomValue();
    }

    public override void Undo()
    {
        _calculator.Value = _previousValue;
    }
}