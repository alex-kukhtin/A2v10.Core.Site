using System;
using System.Collections.Generic;
using System.Text;

namespace SiteBuilder
{

	public enum SiteMapMode
	{
		none,
		text,
		xml
	}

	public class Config
	{
		public String root { get; set; }
		public String site { get; set; }
		public List<String> files { get; set; }
		public List<String> urls { get; set; }
		public SiteMapMode sitemap { get; set; }
	}
}
