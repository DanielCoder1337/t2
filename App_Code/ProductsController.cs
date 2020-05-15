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
using Umbraco.Core.Logging;
namespace Umbraco8.Controllers
{
	public class ProductsController : UmbracoApiController
	{
		public IHttpActionResult GetAllProducts()
		{
			var t1 = UmbracoContext.ContentCache.GetByXPath("//products").First();
			List<Product> returnArray = new List<Product>();
			foreach(var productNode in t1.Children)
			{
				returnArray.Add(new Product
				{
				Name = productNode.Name,
				Id = productNode.Id,
				Category = productNode.Value<IEnumerable<string>>("category"),
				Description = productNode.Value<string>("description"),
				Price = productNode.Value<float>("price"),
				ImageUrl = "http://localhost:32604" + productNode.Value<IPublishedContent>("photos").GetCropUrl(250, 250)
				});
			}
			return Ok(returnArray);
		}

		public IHttpActionResult GetProductById(int id)
		{
			var product = Umbraco.Content(id);
			return Ok(new Product{
				Name = product.Name,
				Id = product.Id,
				Category = product.Value<IEnumerable<string>>("category"),
				Description = product.Value<string>("description"),
				Price = product.Value<float>("price"),
				ImageUrl = "http://localhost:32604" + product.Value<IPublishedContent>("photos").GetCropUrl(375, 600)
			});
		}
	}
	public class Product
	{
	public string Name { get; set; }
	public int Id {get; set;}
	public IEnumerable<string> Category { get; set; }
	public string Description { get; set; }
	public float Price {get; set;}
	public string ImageUrl {get; set;}
	}
}
