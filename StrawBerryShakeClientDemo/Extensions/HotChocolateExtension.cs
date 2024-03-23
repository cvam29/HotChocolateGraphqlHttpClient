using HotChocolate.Transport.Http;
using HotChocolate.Transport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace StrawBerryShakeClientDemo.Extensions;
internal static class HotChocolateExtension
{
	public static async Task<OperationResult> ExecuteGraphQLQuery<T>(this GraphQLHttpClient _gqlClient, string query, object variables)
	{
		try
		{
			var variable = ToReadOnlyDictionary(variables);
			var operation = new OperationRequest(query, variables: variable);
			var request = new GraphQLHttpRequest(operation);

			var response = await _gqlClient.SendAsync(request);
			var result = await response.ReadAsResultAsync();
			var jsonData = result.Data.ToString();

			if (!string.IsNullOrWhiteSpace(jsonData))
			{
				return result;
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

}
