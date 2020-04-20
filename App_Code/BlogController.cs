using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using Newtonsoft.Json;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco;

namespace Umbraco8.Controllers
{

	public class BlogController : UmbracoApiController
	{
		public IHttpActionResult GetAllBlogs()
		{
			var t1 = UmbracoContext.ContentCache.GetByXPath("//blog").First();
			List<Blog> blogArray = new List<Blog>();
			foreach(var blog in t1.Children)
			{
				blogArray.Add(new Blog
				{
				Name = blog.Name,
				Id = blog.Id,
				Title = blog.Value<string>("pageTitle"),
				Categories =  blog.Value<IEnumerable<string>>("categories"),
				Excerpt = blog.Value<string>("excerpt"),
				Content = blog.Value<string>("bodyText")
				});
			}
			return Ok(blogArray);
		}

		public IHttpActionResult GetBlogById(int id)
		{
			var blog = Umbraco.Content(id);
			return Ok(new Blog {
				Name = blog.Name,
				Title = blog.Value<string>("pageTitle"),
				Categories =  blog.Value<IEnumerable<string>>("categories"),
				Excerpt = blog.Value<string>("excerpt"),
				Content = blog.Value<string>("bodyText")
			});
		}
	}
	public class Blog
	{
	public string Name { get; set; }
	public int Id { get; set; }
	public string Title { get; set; }
	public IEnumerable<string> Categories { get; set; }
	public string Excerpt { get; set; }
	public string Content { get; set; }

	}
}
