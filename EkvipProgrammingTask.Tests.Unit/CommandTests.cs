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

    // Custom mock class for testing
    public class MockCommand : Command
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