namespace EkvipProgrammingTask.Commands;

public class Double : Command
{
    private readonly SimpleCalculator _calculator;
    private readonly int _previousValue;

    public Double(SimpleCalculator calculator) : base(calculator)
    {
        _calculator = calculator;
        _previousValue = calculator.Value;
    }

    public override void Execute()
    {
        _calculator.Double();
    }

    public override void Undo()
    {
        _calculator.Value = _previousValue;
    }
}