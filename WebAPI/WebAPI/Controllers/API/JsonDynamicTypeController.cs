using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers.API
{
    public class JsonDynamicTypeController : ApiController
    {
        // GET: api/JsonDynamicType
        // Test: http://localhost:25399/api/JsonDynamicType
        public dynamic Get()
        {
            // Querying JSON with dynamic
            // http://www.newtonsoft.com/json/help/html/QueryJsonDynamic.htm
            string json = @"
               {
                 'Title': 'Json.NET is awesome!',
                 'Author': {
                   'Name': 'James Newton-King',
                   'Twitter': '@JamesNK',
                   'Picture': '/jamesnk.png'
                 },
                 'Date': '2013-01-23T19:30:00',
                'BodyHtml': '&lt;h3&gt;Title!&lt;/h3&gt;\r\n&lt;p&gt;Content!&lt;/p&gt;'
              }";

            dynamic blogPost = JObject.Parse(json);

            string title = blogPost.Title;
            string author = blogPost.Author.Name;
            DateTime postDate = blogPost.Date;

            Debug.WriteLine($"Title: {title}, Author: {author}, DateTime: {postDate}");

            // Hm, blogPost.Title is also dynamic type and needs type casting
            title = ((string)blogPost.Title).Replace("is", "& daynamic type are"); 
            blogPost.Title = title;

            return blogPost;
        }

        // GET: api/JsonDynamicType/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/JsonDynamicType
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/JsonDynamicType/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/JsonDynamicType/5
        public void Delete(int id)
        {
        }
    }
}
