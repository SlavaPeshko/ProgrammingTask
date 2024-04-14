using EkvipProgrammingTask.Commands;

namespace EkvipProgrammingTask.Tests.Unit;

[TestFixture]
public class IncrementTests
{
    [Test]
    public void Execute_ShouldIncrementCalculatorValue()
    {
        // Arrange
        var initialValue = 5;
        var calculator = new SimpleCalculator()
        {
            Value = initialValue
        };
        var increment = new Increment(calculator);

        // Act
        increment.Execute();

        // Assert
        Assert.AreEqual(initialValue + 1, calculator.Value);
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
        var increment = new Increment(calculator);

        // Act
        increment.Execute();
        increment.Undo();

        // Assert
        Assert.AreEqual(initialValue, calculator.Value);
    }
}