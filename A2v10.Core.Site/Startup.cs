using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace A2v10.Core.Site
{

	public class LangLocationExpander : IViewLocationExpander
	{
		public IEnumerable<String> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<String> viewLocations)
		{
			var lang = context.Values["lang"];
			return new String[] {
				$"/Views/{{1}}/{lang}/{{0}}.cshtml",
				$"/Views/Shared/{lang}/{{0}}.cshtml"
			};
		}

		public void PopulateValues(ViewLocationExpanderContext context)
		{
			context.Values.Add("lang", context.ActionContext.RouteData.Values["lang"].ToString());
		}
	}

	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<RazorViewEngineOptions>(opts =>
			{
				opts.ViewLocationExpanders.Add(new LangLocationExpander());
			});
			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseDefaultFiles()
				.UseHttpsRedirection()
				.UseStaticFiles()
				.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{lang=uk}/{action=index}/{id?}",
					defaults: new { controller = "home" }
				);
			});
		}
	}
}
