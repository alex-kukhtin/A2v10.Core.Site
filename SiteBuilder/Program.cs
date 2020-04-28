// Copyright © 2020 Alex Kukhtin. All rights reserved.

using System;
using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace SiteBuilder
{
	class Program
	{
		static async Task<Int32> Main(String[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine("Usage SiteBuilder.exe config.file");
				return -1;
			}

			try
			{
				String json = File.ReadAllText(args[0]);

				var config = JsonConvert.DeserializeObject<Config>(json);

				var siteProcessor = new SiteProcessor(config);
				await siteProcessor.Build();
				return 0;
			} 
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return -1;
			}
		}
	}
}
