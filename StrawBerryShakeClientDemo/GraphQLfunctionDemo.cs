namespace StrawBerryShakeClientDemo;
public  class GraphQLfunctionDemo
{
    private readonly HotChocolateClientFactory _clientFactory;
    public GraphQLfunctionDemo(HotChocolateClientFactory clientFactory)
    {
            _clientFactory = clientFactory;
    }

    [FunctionName("GraphQLfunctionDemo")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        var client = _clientFactory.CreateClient();

        var Gqlreq = new GraphQL.GraphQLRequest()
        {
            Query = Query.GetQuery(),
            Variables = new { uid = "12" },
        };

        var result = await client.SendQueryAsync<dynamic>(Gqlreq);
        var data = Convert.ToString( result.Data);


        return new OkObjectResult(new { data, result.Errors });
    }
}
