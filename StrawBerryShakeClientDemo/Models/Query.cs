namespace StrawBerryShakeClientDemo.Models;
public static class Query
{

    private const string _query = @"{
      all_brand {
        items {
          title
        }
      }
}
    ";

    public static string GetQuery()
    {
        return _query;
    }
 
}
