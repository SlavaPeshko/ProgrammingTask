namespace EkvipProgrammingTask.Tests.Unit;
using Double = EkvipProgrammingTask.Commands.Double;

public class DoubleTests
{
    [Test]
    public void Execute_ShouldDoubleCalculatorValue()
    {
        // Arrange
        var initialValue = 5;
        var calculator = new SimpleCalculator(initialValue);
        var doubleCommand = new Double(calculator);

        // Act
        doubleCommand.Execute();

        // Assert
        Assert.AreEqual(initialValue * 2, calculator.Value);
    }

    [Test]
    public void Undo_ShouldRestorePreviousValue()
    {
        // Arrange
        var initialValue = 5;
        var calculator = new SimpleCalculator(initialValue);
        var doubleCommand = new Double(calculator);

        // Act
        doubleCommand.Execute();
        doubleCommand.Undo();

        // Assert
        Assert.AreEqual(initialValue, calculator.Value);
    }
}