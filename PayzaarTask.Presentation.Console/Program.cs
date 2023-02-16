/*
 * TODO:
 *	- refactor, find all the issues you can and fix them
 *	- change the code to follow clean architecture principles
 *	- apply design patterns where you think it is required
 *	- do not change the output
 *	- make sure the refactored code is testable (you are allowed to write a test or two as a PoC)
 *	- add comments, highlighting what you changed and what was the reason for change
 */

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PayzaarTask.Business.Extension;

namespace PayzaarRefactorCodingTask
{
    class Program
    {
        // I changed the Program to create a HostBuilder so now we an use DI.
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // We inject the Worker service so we use it as a entry point to execute the code.
                    services.AddHostedService<Worker>()
                            .AddBusinessServices();
                });
    }
}
