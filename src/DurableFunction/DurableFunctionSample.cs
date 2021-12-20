using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DurableFunction
{

    public class DurableFunctionSample
    {
        private readonly IOptions<FunctionOption> _options;

        public DurableFunctionSample(IOptions<FunctionOption> options)
        {
            _options = options;
        }

        [FunctionName("DurableFunctionSample")]
        public async Task<List<string>> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var request = context.GetInput<FunctionRequest>();
            var outputs = new List<string> { await context.CallActivityAsync<string>("DurableFunction_Activity", request) };

            return outputs;
        }

        [FunctionName("DurableFunction_Activity")]
        public string DoAction([ActivityTrigger] FunctionRequest request, ILogger log)
        {
            log.LogInformation($"Value from configuration: {_options.Value.Name}");
            log.LogInformation($"Value from request: {request.Name}--{request.Family}");

            return "Done";
        }

        [FunctionName("DurableFunctionSample_http")]
        public async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            var request = new FunctionRequest();

            //in case of get request like http://localhost:7071/api/Function1_HttpStart?name=durable&family=function
            if (req.Method == HttpMethod.Get)
                req.RequestUri.TryReadQueryAs(out request);

            //in case of post request read request body
            if (req.Method == HttpMethod.Post)
            {
                if (req.Content == null)
                    return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Invalid request content.") };

                //read body request
                request = JsonConvert.DeserializeObject<FunctionRequest>(await req.Content.ReadAsStringAsync());
            }

            // Function input comes from the request content.
            string instanceId = await starter.StartNewAsync("DurableFunctionSample", request);

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}