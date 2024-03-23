using System.Collections.Generic;

namespace StrawBerryShakeClientDemo.Models;

public class AllFullWidthTemplateCSResponse
{
	public AllFullWidthTemplateData data { get; set; }
}

public class AllFullWidthTemplateData
{
	public AllFullWidthTemplate all_full_width_template { get; set; }
}

public class AllFullWidthTemplate
{
	public List<AllFullWidthTemplateCSResponseItem> items { get; set; }

	public int total { get; set; }
}

public class AllFullWidthTemplateCSResponseItem
{
	public string meta_description { get; set; }

	public List<string> meta_keywords { get; set; }

	public string meta_title { get; set; }

	public string url { get; set; }
	public string title { get; set; }

	public SiteSearch site_search { get; set; }

	public List<string> fwt_tags { get; set; }

	public OpenGraphImageConnection open_graph_imageConnection { get; set; }

	public ContentConnection contentConnection { get; set; }
}

public class ContentConnection
{
	public List<OgEdge> edges { get; set; }
}

public class OgEdge
{
	public OgNode node { get; set; }
}


public class OgNode
{
	public string url { get; set; }
	public string title { get; set; }

	public string page_description { get; set; }
}

public class OpenGraphImageConnection
{
	public List<OgEdge> edges { get; set; }
}

public class SiteSearch
{
	public List<string> search_keywords { get; set; }
	public string search_content_summary { get; set; }
}


