using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using StrawBerryShakeClientDemo.Services;
using StrawBerryShakeClientDemo.Models;
using StrawBerryShakeClientDemo.Extensions;

namespace StrawBerryShakeClientDemo
{

	public  class GraphQlClientfunction
    {
        private readonly HotChocolateClientFactory _clientFactory;
        public GraphQlClientfunction(HotChocolateClientFactory clientFactory)
        {
                _clientFactory = clientFactory;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var client = _clientFactory.CreateClient();

            var q = Query.GetFullWidthTemplatesByIds;

            var variables = new { uid = "" };

            var result = await client.ExecuteGraphQLQuery<AllFullWidthTemplateData>(q, variables);
            var data = result.Data.ToString();


            return new OkObjectResult(new { data, result.Errors });
        }
    }
}
