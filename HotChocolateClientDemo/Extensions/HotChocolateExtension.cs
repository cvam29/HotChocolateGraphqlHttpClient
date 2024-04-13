namespace StrawBerryShakeClientDemo.Extensions;
public static class HotChocolateExtension
{
    public static async Task<GraphQLResponse<T>> SendQueryAsync<T>(this GraphQLHttpClient _gqlClient,GraphQL.GraphQLRequest req)
    {
        try
        {
            var variable = ToReadOnlyDictionary(req.Variables);
            var operation = new OperationRequest(req.Query, variables: variable);
            var request = new GraphQLHttpRequest(operation);

            var response = await _gqlClient.SendAsync(request);
            var operationResult = await response.ReadAsResultAsync();

            if (operationResult != null)
            {
                return operationResult.ToGraphQLResponse<T>();
            }
            else
            {
                return default; // Return default value of type T if response data is null
            }
        }
        catch (Exception ex)
        {
            // Log or handle the exception as needed
            Console.WriteLine($"Exception: {ex.Message}");
            return default; // Return default value of type T on exception
        }
    }

    public static IReadOnlyDictionary<string, object> ToReadOnlyDictionary(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		var dictionary = new Dictionary<string, object>();

		// Get properties of the object
		var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

		foreach (var property in properties)
		{
			var propertyName = property.Name;
			var propertyValue = property.GetValue(obj);
			dictionary.Add(propertyName, propertyValue);
		}

		return dictionary;
	}

    public static GraphQLResponse<T> ToGraphQLResponse<T>(this OperationResult operationResult)
    {
        // Assuming that the Data property in OperationResult can be deserialized to the type T
        T data = JsonConvert.DeserializeObject<T>(operationResult.Data.GetRawText());

        // Assuming that the Errors property in OperationResult can be deserialized to GraphQLError[]
        GraphQL.GraphQLError[]? errors = JsonConvert.DeserializeObject<GraphQL.GraphQLError[]>(operationResult.Errors.GetRawText());

        // Assuming that the Extensions property in OperationResult can be deserialized to Map

        return new GraphQLResponse<T>
        {
            Data = data,
            Errors = errors,
        };
    }

}
