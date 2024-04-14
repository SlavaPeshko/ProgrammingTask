namespace EkvipProgrammingTask
{
    internal class Program
    {
        private static readonly Dictionary<string, CommandType> CommandTypes = new Dictionary<string, CommandType>
        {
            { Constants.Increment, CommandType.Increment },
            { Constants.Decrement, CommandType.Decrement },
            { Constants.Double, CommandType.Double },
            { Constants.Randadd, CommandType.AddRandomValue },
            { Constants.Undo, CommandType.Undo }
        };

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No arguments were passed.");
                return;
            }

            var value = args.FirstOrDefault();
            if (!int.TryParse(value, out var parsedValue))
            {
                Console.WriteLine("The argument isn't value.");
                return;
            }

            var calculator = new SimpleCalculator(parsedValue);
            var commandManager = new CommandManager();

            // Exiting the Program, like to add command to exit the program
            Console.WriteLine("Only 5 commands are available: increment, decrement, double, randadd and undo");
            while (true)
            {
                try
                {
                    var input = Console.ReadLine();
                    var commandType = DetectorCommandType(input);

                    if (commandType == CommandType.Undo)
                        commandManager.Undo();
                    else
                    {
                        var command = commandManager.GetCommand(commandType, calculator);
                        commandManager.ExecuteCommand(command);
                    }

                    Console.WriteLine($"Current value: {calculator.Value}");
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        static CommandType DetectorCommandType(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException(nameof(input));

            var key = input.Trim().ToLowerInvariant();

            if (CommandTypes.TryGetValue(key, out var commandType))
                return commandType;

            throw new ArgumentException("Unknown command " + input);
        }
    }
}