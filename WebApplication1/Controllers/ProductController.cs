using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //ma zwracac liste produktów
            Models.Products allEntity = new Models.Products();
            
             String[] information = allEntity.returnAllEntity();
            return information;
            //return new string[] { "value1222", "value23333" };
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            Models.Products asdf = new Models.Products();
            string info = asdf.returnList(id);
            return info;
            //ma zwracac produkt o danym id

        }

        public class myModel
        {
            public string Key { get; set; }
            public int Id { get; set; }
            public double price { get; set; }
        }

        [HttpPost]
        public string Post([FromBody] Models.model model )
        {
            //save entity + validators inside class model
            return model.ProductCreateInputModel();
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //aktualizuje dany produkt
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //usuwa produkt
        }
    }
}