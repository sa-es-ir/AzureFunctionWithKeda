using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace TimerTriggerFunction
{
    public class TimerTriggerSample
    {
        private readonly IOptions<FunctionOption> _options;

        public TimerTriggerSample(IOptions<FunctionOption> options)
        {
            _options = options;
        }

        [FunctionName("TimerTriggerSample")]
        public void Run([TimerTrigger("0 */2 * * * *", RunOnStartup = true)] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            log.LogInformation($"this is from configurations: Name:{_options.Value.Name}");
        }
    }
}
