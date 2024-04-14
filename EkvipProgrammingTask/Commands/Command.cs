namespace EkvipProgrammingTask.Commands;

public abstract class Command
{
    protected readonly SimpleCalculator Receiver;
    public Command(SimpleCalculator receiver)
    {
        Receiver = receiver ?? throw new ArgumentException(nameof(receiver));
    }
    public abstract void Execute();
    public abstract void Undo();
}