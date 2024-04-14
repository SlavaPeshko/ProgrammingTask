using EkvipProgrammingTask.Commands;

namespace EkvipProgrammingTask.Tests.Unit;

public class AddRandomValueTests
{
    [Test]
    public void Execute_ShouldIncreaseCalculatorValueByRandomAmount()
    {
        // Arrange
        var initialValue = 5;
        var calculator = new SimpleCalculator(initialValue);
        var addRandomValue = new AddRandomValue(calculator);

        // Act
        addRandomValue.Execute();

        // Assert
        Assert.AreNotEqual(initialValue, calculator.Value); // Ensure the value changed
    }

    [Test]
    public void Undo_ShouldRestorePreviousValue()
    {
        // Arrange
        var initialValue = 5;
        var calculator = new SimpleCalculator(initialValue);
        var addRandomValue = new AddRandomValue(calculator);

        // Act
        addRandomValue.Execute();
        addRandomValue.Undo();

        // Assert
        Assert.AreEqual(initialValue, calculator.Value);
    }
}