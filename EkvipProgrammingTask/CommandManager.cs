using EkvipProgrammingTask.Commands;
using Double = EkvipProgrammingTask.Commands.Double;

namespace EkvipProgrammingTask;

public class CommandManager
{
    private readonly Stack<Command> _commandStack;
    private readonly Dictionary<CommandType, Func<SimpleCalculator, Command>> _commands;

    public CommandManager()
    {
        _commandStack = new Stack<Command>();
        _commands = new Dictionary<CommandType, Func<SimpleCalculator, Command>>
        {
            { CommandType.Increment, (calculator) => new Increment(calculator) },
            { CommandType.Decrement, (calculator) => new Decrement(calculator) },
            { CommandType.Double, (calculator) => new Double(calculator) },
            { CommandType.AddRandomValue, (calculator) => new AddRandomValue(calculator) }
        };
    }

    // Executes a command and adds it to the command stack
    public void ExecuteCommand(Command command)
    {
        command.Execute();
        _commandStack.Push(command);
    }

    // Undoes the last executed command
    public void Undo()
    {
        if (_commandStack.Count <= 0) return;

        var cmd = _commandStack.Pop();
        cmd.Undo();
    }

    // Retrieves a command of a given type
    public Command GetCommand(CommandType commandType, SimpleCalculator simpleCalculator)
    {
        if (simpleCalculator == null)
            throw new ArgumentNullException(nameof(simpleCalculator));

        if (!_commands.TryGetValue(commandType, out var command))
            throw new ArgumentException("Unknown command " + commandType);

        return command.Invoke(simpleCalculator);
    }
}