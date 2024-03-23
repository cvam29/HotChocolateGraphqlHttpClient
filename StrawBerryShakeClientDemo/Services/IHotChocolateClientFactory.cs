using HotChocolate.Transport.Http;
using System.Threading;
using System.Threading.Tasks;

namespace StrawBerryShakeClientDemo.Services;
public interface IHotChocolateClientFactory
{
	GraphQLHttpClient CreateClient();
	Task<GraphQLHttpResponse> SendAsync(GraphQLHttpRequest request, CancellationToken cancellationToken = default);
}