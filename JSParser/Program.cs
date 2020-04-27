using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace JSParser
{
	class Program
	{
		static void CheckHtmlTemplate(Token tok)
		{
			if (tok.Type != Token.TokenType.String)
				return;
			if (!tok.Value.StartsWith('`'))
				return;
			// TODO: сделать покрасивше
			String tv = tok.Value.Substring(1, tok.Value.Length - 2).Trim();
			if (tv.StartsWith('<') && tv.EndsWith('>'))
				tok.SetValue(Regex.Replace(tok.Value, @"\s+", " "));
		}

		static void Main(string[] args)
		{
			//String source = @"D:\Git\A2v10.Core.Site\A2v10.Core.Site\Scripts\output.js";
			//String target = @"D:\Git\A2v10.Core.Site\A2v10.Core.Site\Scripts\output.min.js";
			String source = @"C:\Git\A2v10\Web\A2v10.Web.Site\scripts\main.js";
			String target = @"C:\Git\A2v10\Web\A2v10.Web.Site\scripts\main.min.js";
			File.Delete(target);
			using var sr = new StreamReader(source, Encoding.UTF8);
			using var tr = new StreamWriter(target, false, Encoding.UTF8);
			var tok = new Tokenizer(sr);
			while (tok.NextToken())
			{
				var t = tok.Token;
				if (t.Type == Token.TokenType.Comment)
					continue;
				CheckHtmlTemplate(t);
				if (t.SpaceAfter)
				{
					//Console.Write(t.Value);
					//Console.Write(" ");
					tr.Write(t.Value);
					tr.Write(" ");
				} 
				else if (t.SpaceBeforeAndAfter)
				{ 
					/*
					Console.Write(" ");
					Console.Write(t.Value);
					Console.Write(" ");
					*/
					tr.Write(" ");
					tr.Write(t.Value);
					tr.Write(" ");
				}
				else
				{
					//Console.Write(t.Value);
					tr.Write(t.Value);
				}
			}
		}
	}
}
