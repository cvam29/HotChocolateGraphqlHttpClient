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

    public const string FullWidthTemplateProps = @"
query FullWidthProps($uid: String!) {
full_width_template(uid: $uid) {
system{
uid
content_type_uid
}
title
heading_description
url
meta_title
meta_description
meta_keywords
hide_breadcrumbs_
open_graph_imageConnection{
edges{
node{
title
url
filename
description
system{
uid
}
}
}
}
}
}
";

	public const string GetFullWidthTemplatesByIds = @" {
          all_full_width_template(where: { exclude_from_site_map_ne: ""Yes""}) {
            items {
              exclude_from_site_map   
              meta_description
              meta_keywords
              meta_title
              url
              title
              system {
                uid
                publish_details {
                  time
                }
              }
              site_search {
                search_keywords
                search_content_summary
              }
              open_graph_imageConnection {
                edges {
                  node {
                    url
                    title
                  }
                }
              }
              contentConnection {
                edges {
                  node {
                    ... on PageTitle {
                      title
                      page_description
                    }
                  }
                }
              }
            }
            total
          }
    }";
}
