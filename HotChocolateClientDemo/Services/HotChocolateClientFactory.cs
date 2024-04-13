namespace StrawBerryShakeClientDemo.Services;

public class HotChocolateClientFactory : GraphQLHttpClient, IHotChocolateClientFactory
{
	private readonly IHttpClientFactory _clientFactory;
	private readonly GraphQLOptions _graphQLOptions;
	public const string EncodingType = "gzip";

	public HotChocolateClientFactory(IOptions<GraphQLOptions> graphQLOptions, 
									IHttpClientFactory httpClientFactory )
	{
		_graphQLOptions = graphQLOptions.Value;
		_clientFactory = httpClientFactory;
	}


	public GraphQLHttpClient CreateClient()
	{
		var client = _clientFactory.CreateClient();
		client.BaseAddress = new Uri(_graphQLOptions.Endpoint);
		client.DefaultRequestHeaders.Add("access_token", _graphQLOptions.DeliveryToken);
		client.DefaultRequestHeaders.Add("branch", _graphQLOptions.Branch);
		client.DefaultRequestHeaders.Add("accept_encoding", EncodingType);
		return Create(client, false);
	}
	public override async Task<GraphQLHttpResponse> SendAsync(GraphQLHttpRequest request, CancellationToken cancellationToken = default)
	{
		var client = CreateClient();

		var response = await client.SendAsync(request, cancellationToken);

		return response;
	}
}