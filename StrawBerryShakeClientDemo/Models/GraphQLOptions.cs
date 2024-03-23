namespace StrawBerryShakeClientDemo.Models;
public class GraphQLOptions
{
    public string Host { get; set; }
    public string ApiKey { get; set; }
    public string DeliveryToken { get; set; }
    public string Environment { get; set; }

    public string Endpoint
    {
        get
        {
            var protocol = Host?.StartsWith("https://") ?? false ? string.Empty : "https://";
            return $"{protocol}{Host}/stacks/{ApiKey}?environment={Environment}";
        }
    }

    public string Branch { get; set; }
    public string ManagementToken { get; set; }
}
