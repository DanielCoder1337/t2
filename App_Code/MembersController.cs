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

	public class PeopleController : UmbracoApiController
	{
		public IHttpActionResult GetAllPeople()
		{
			var t1 = UmbracoContext.ContentCache.GetByXPath("//people").First();
			List<Person> peopleArray = new List<Person>();
			foreach(var person in t1.Children)
			{
				peopleArray.Add(new Person
				{
				Name = person.Name,
				Id = person.Id,
				Email = person.Value<String>("email"),
				Twitter_username = person.Value<String>("twitterUsername"),
				Facebook_username = person.Value<String>("facebookUsername"),
				LinkedIn_username = person.Value<String>("linkedInUsername"),
				Instagram_username = person.Value<String>("instagramUsername"),
				ImageUrl = "http://localhost:32604" + person.Value<IPublishedContent>("photo").GetCropUrl(250, 250)
				});
			}
			return Ok(peopleArray);
		}
		public IHttpActionResult GetPersonById(int id)
		{
			var person = Umbraco.Content(id);
			return Ok(new Person{
				Name = person.Name,
				Id = person.Id,
				Email = person.Value<String>("email"),
				Twitter_username = person.Value<String>("twitterUsername"),
				Facebook_username = person.Value<String>("facebookUsername"),
				LinkedIn_username = person.Value<String>("linkedInUsername"),
				Instagram_username = person.Value<String>("instagramUsername"),
				ImageUrl = "http://localhost:32604" + person.Value<IPublishedContent>("photo").GetCropUrl(375, 600)
			});
		}
	}
	public class Person
	{
	public string Name { get; set; }
	public int Id { get; set; }
	public string Email { get; set; }
	public string Twitter_username { get; set; }
	public string Facebook_username { get; set; }
	public string LinkedIn_username { get; set; }
	public string Instagram_username { get; set; }
	public string ImageUrl {get; set;}

	}
}
