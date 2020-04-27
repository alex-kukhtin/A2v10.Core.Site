using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SiteBuilder
{
	class Program
	{
		static async Task Main(string[] args)
		{
			String siteMapPath = "../../../sitemap.txt";
			String targetPath = "d:/temp/staticsite";

			String json = "{}";

			var config = JsonConvert.DeserializeObject<Config>(json);

			var lines = File.ReadAllLines(siteMapPath);
			var siteProcessor = new SiteProcessor(targetPath);
			foreach (var line in lines)
			{
				if (line.StartsWith(";"))
					continue;
				if (line.StartsWith("#"))
				{
					siteProcessor.SetUrl(line.Substring(1));
					continue;
				}
				await siteProcessor.ProcessOneFile(line);
			}
		}
	}
}
