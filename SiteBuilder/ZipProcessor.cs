// Copyright © 2020 Alex Kukhtin. All rights reserved.

using System;
using System.IO;
using System.IO.Compression;

namespace SiteBuilder
{
	public class ZipProcessor
	{
		private readonly String _zipName;
		private readonly String _dirName;

		public ZipProcessor(String dir)
		{
			_dirName = Path.GetFullPath(dir);
			_zipName = Path.GetFullPath($"{dir}/../site.zip");
		}

		public void Build()
		{
			if (File.Exists(_zipName))
				File.Delete(_zipName);
			using var za = ZipFile.Open(_zipName, ZipArchiveMode.Create);
			AddFilesFromDirectory(za, "");
		}

		public String ZipName => _zipName;

		void AddFilesFromDirectory(ZipArchive za, String dir)
		{
			String srcDir = Path.Combine(_dirName, dir);
			foreach (var f in Directory.GetFiles(srcDir))
			{
				String fn = Path.GetFileName(f);
				za.CreateEntryFromFile(f, Path.Combine(dir, fn).Replace("\\", "/"));
			}
			foreach (var d in Directory.GetDirectories(srcDir))
			{
				String subDir = Path.Combine(dir, Path.GetFileName(d)).Replace("\\", "/");
				AddFilesFromDirectory(za, subDir);
			}
		}
	}
}
