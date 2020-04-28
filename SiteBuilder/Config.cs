// Copyright © 2020 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Generic;

namespace SiteBuilder
{

	public enum SiteMapFormat
	{
		none,
		text,
		xml
	}

	public class SiteMap
	{
		public SiteMapFormat format { get; set; }
		public String host { get; set; }
	}

	public class Config
	{
		public String source { get; set; }
		public String target { get; set; }
		public String fileSource { get; set; }

		public List<String> pages { get; set; }
		public List<String> @static { get; set; }
		public List<String> @files { get; set; }

		public Boolean makezip { get; set; }
		public SiteMap sitemap { get; set; }
	}
}
