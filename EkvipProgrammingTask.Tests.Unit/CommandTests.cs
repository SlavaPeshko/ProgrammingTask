using Moq;
using EkvipProgrammingTask.Commands;

namespace EkvipProgrammingTask.Tests.Unit;

[TestFixture]
public class CommandTests
{
    [Test]
    public void Constructor_NullReceiver_ThrowsArgumentException()
    {
        // Arrange, Act, Assert
        Assert.Throws<ArgumentException>(() => new MockCommand(null));
    }

    [Test]
    public void Execute_ShouldCallExecuteMethodOnReceiver()
    {
        // Arrange
        var mockReceiver = new Mock<SimpleCalculator>();
        var command = new MockCommand(mockReceiver.Object);

        // Act
        command.Execute();

        // Assert
        mockReceiver.Verify(m => m.Increment(), Times.Once);
    }

    [Test]
    public void Undo_ShouldCallUndoMethodOnReceiver()
    {
        // Arrange
        var mockReceiver = new Mock<SimpleCalculator>();
        var command = new MockCommand(mockReceiver.Object);

        // Act
        command.Undo();

        // Assert
        mockReceiver.Verify(m => m.Decrement(), Times.Once);
    }

    // Custom mock class for testing
    private class MockCommand : Command
    {
        public MockCommand(SimpleCalculator receiver) : base(receiver) { }

        public override void Execute()
        {
            Receiver.Increment();
        }

        public override void Undo()
        {
            Receiver.Decrement();
        }
    }
}