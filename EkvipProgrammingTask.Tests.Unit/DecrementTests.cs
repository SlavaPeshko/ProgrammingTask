using EkvipProgrammingTask.Commands;

namespace EkvipProgrammingTask.Tests.Unit;

[TestFixture]
public class DecrementTests
{
    [Test]
    public void Execute_ShouldDecrementCalculatorValue()
    {
        // Arrange
        var initialValue = 5;
        var calculator = new SimpleCalculator()
        {
            Value = initialValue
        };
        var decrement = new Decrement(calculator);

        // Act
        decrement.Execute();

        // Assert
        Assert.AreEqual(initialValue - 1, calculator.Value);
    }

    [Test]
    public void Undo_ShouldRestorePreviousValue()
    {
        // Arrange
        var initialValue = 5;
        var calculator = new SimpleCalculator()
        {
            Value = initialValue
        };
        var decrement = new Decrement(calculator);

        // Act
        decrement.Execute();
        decrement.Undo();

        // Assert
        Assert.AreEqual(initialValue, calculator.Value);
    }
}