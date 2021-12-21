using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace QueueTriggerFunction
{
    public class QueueTriggerSample
    {
        [FunctionName("QueueTriggerSample")]
        public void Run([QueueTrigger("function-queue-keda", Connection = "AzureWebJobStorage")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
