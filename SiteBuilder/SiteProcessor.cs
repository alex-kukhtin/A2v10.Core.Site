// Copyright © 2020 Alex Kukhtin. All rights reserved.

using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SiteBuilder
{
	public class SiteProcessor
	{

		private readonly Config _config;
		private readonly HttpClient _httpClient = new HttpClient();

		public SiteProcessor(Config config)
		{
			_config = config;
		}

		public async Task Build()
		{
			var target = Path.GetFullPath(_config.target);
			Console.WriteLine($"Source site: {_config.source}");
			Console.WriteLine($"Target path: {target}");
			Console.WriteLine();
			if (Directory.Exists(target))
				Directory.Delete(target, true);
			Directory.CreateDirectory(target);

			if (_config.pages != null)
				foreach (var page in _config.pages)
					await ProcessOneFile(page, "page");
			if (_config.@static != null)
				foreach (var file in _config.@static)
					await ProcessOneFile(file, "static");
			if (_config.files != null)
				foreach (var file in _config.@files)
					ProcessOneStaticFile(file, "file");
			CreateSiteMap();

			if (_config.makezip)
			{
				var zip = new ZipProcessor(_config.target);
				Console.WriteLine();
				Console.WriteLine($"Make zip-archive: {zip.ZipName}");
				zip.Build();
			}
		}

		void ProcessOneStaticFile(String url, String title)
		{
			String source = Path.GetFullPath(Path.Combine(_config.fileSource, url));
			String target = Path.GetFullPath(Path.Combine(_config.target, url));
			Console.WriteLine($"{title}: '{url}'");
			File.Copy(source, target, true);
		}

		async Task ProcessOneFile(String url, String title)
		{
			if (!url.StartsWith("/"))
				url = "/" + url;
			Console.WriteLine($"{title}: '{url}'");
			var target = _config.target;

			using var response = await _httpClient.GetAsync(_config.source + url);
			if (response.IsSuccessStatusCode)
			{
				if (url == "/")
					url = "/index";

				String targetPath;
				if (Path.GetExtension(url) == String.Empty)
					targetPath = $"{ target}/html{url}.html";
				else
					targetPath = target + url;

				String dirName = Path.GetDirectoryName(targetPath);
				Directory.CreateDirectory(dirName);

				var bytes = await response.Content.ReadAsByteArrayAsync();
				await File.WriteAllBytesAsync(targetPath, bytes);
			} 
			else
			{
				throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
			}
		}

		void CreateSiteMap()
		{
			if (_config.sitemap == null)
				return;
			if (_config.sitemap.format == SiteMapFormat.none)
				return;
			if (_config.sitemap.format != SiteMapFormat.text)
				throw new NotImplementedException($"Sitemap.format '{_config.sitemap.format}'. Yet not implemented");

			var target = Path.GetFullPath(Path.Combine(_config.target, "sitemap.txt"));

			Console.WriteLine();
			Console.WriteLine($"Make sitemap: {target}");

			var url = _config.sitemap.host;
			if (String.IsNullOrEmpty(url))
				throw new InvalidOperationException("sitemap.host not defined");
			var sb = new StringBuilder();
			foreach (var p in _config.pages)
			{
				var page = p;
				if (!page.StartsWith("/"))
					page = "/" + page;
				sb.AppendLine($"{url}{page}");
			}
			File.WriteAllText(target, sb.ToString());
		}
	}
}
