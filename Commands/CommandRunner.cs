using System;

namespace EFCoreBench.Commands{

    public class CommandRunner : ICommandRunner
    {

        private ITestPerformanceCommand _testPerformanceCommand;

        public CommandRunner(ITestPerformanceCommand testPerformanceCommand)
        {
            _testPerformanceCommand = testPerformanceCommand;
        }

        public void Help()
        {
            Console.Error.WriteLine(@"dotnet run
    testPerformance [iterations] [concurrency] [operations]
    -h, --help         show this message
            ");
        }

        public int Run(string[] args)
        {
            var cmd = args[0];

            try
            {
	            switch (cmd)
	            {
	                case "testPerformance":
	                    if (args.Length != 4)
	                        goto default;
	                    _testPerformanceCommand.Run(int.Parse(args[1]), int.Parse(args[2]), int.Parse(args[3]));
	                    break;
		            case "-h":
		            case "--help":
			            Help();
			            break;
		            default:
			            Help();
			            return 1;
	            }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Console.Error.WriteLine(e.StackTrace);
                return 1;
            }
            return 0;
        }
    }
}
