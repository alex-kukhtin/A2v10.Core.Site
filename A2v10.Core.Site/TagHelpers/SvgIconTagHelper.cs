
/* Copyright © 2020 Alex Kukhtin. All rights reserved. */

using System;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace A2v10.Core.Site.TagHelpers
{
	public class SvgIconTagHelper : TagHelper
	{
		public String Icon { get; set; }

		public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "svg";
			output.Attributes.Add("xmlns", "xxxx");
			output.TagMode = TagMode.StartTagAndEndTag;
			output.Content.SetHtmlContent("<rect x=0 y=0 width=100 height=100></rect>");
			return Task.CompletedTask;
		}
	}

	public class Simple : TagHelper
	{
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "strong";
		}
	}
}
