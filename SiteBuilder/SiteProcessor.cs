using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SiteBuilder
{
	public class SiteProcessor
	{
		private String _url;
		private readonly String _target;
		private readonly HttpClient _httpClient = new HttpClient();

		public SiteProcessor(String target)
		{
			_target = target;
		}

		public void SetUrl(String url)
		{
			_url = url;
		}

		public async Task ProcessOneFile(String fileName)
		{
			Console.WriteLine($"url: '{fileName}'");

			using var response = await _httpClient.GetAsync(_url + fileName);
			var result = await response.Content.ReadAsStringAsync();
			if (fileName == "/")
				fileName = "/index";

			String targetPath;
			if (Path.GetExtension(fileName) == String.Empty)
				targetPath = $"{ _target}/html{fileName}.html";
			else	
				targetPath = _target + fileName;

			String dirName = Path.GetDirectoryName(targetPath);
			Directory.CreateDirectory(dirName);
			File.WriteAllText(targetPath, result);
		}
	}
}
