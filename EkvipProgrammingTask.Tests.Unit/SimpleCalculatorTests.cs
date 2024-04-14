namespace EkvipProgrammingTask.Tests.Unit;

[TestFixture]
public class SimpleCalculatorTests
{
    [Test]
    public void Increment_ShouldIncreaseValueByOne()
    {
        // Arrange
        var initialValue = 5;
        var calculator = new SimpleCalculator()
        {
            Value = initialValue
        };

        // Act
        calculator.Increment();

        // Assert
        Assert.AreEqual(initialValue + 1, calculator.Value);
    }

    [Test]
    public void Decrement_ShouldDecreaseValueByOne()
    {
        // Arrange
        var initialValue = 5;
        var calculator = new SimpleCalculator()
        {
            Value = initialValue
        };

        // Act
        calculator.Decrement();

        // Assert
        Assert.AreEqual(initialValue - 1, calculator.Value);
    }

    [Test]
    public void Double_ShouldDoubleTheValue()
    {
        // Arrange
        var initialValue = 5;
        var calculator = new SimpleCalculator()
        {
            Value = initialValue
        };

        // Act
        calculator.Double();

        // Assert
        Assert.AreEqual(initialValue * 2, calculator.Value);
    }

    [Test]
    public void AddRandomValue_ShouldIncreaseValueByRandomAmount()
    {
        // Arrange
        var initialValue = 5;
        var calculator = new SimpleCalculator()
        {
            Value = initialValue
        };;

        // Act
        calculator.AddRandomValue();

        // Assert
        Assert.AreNotEqual(initialValue, calculator.Value); // Ensure the value changed
    }
}