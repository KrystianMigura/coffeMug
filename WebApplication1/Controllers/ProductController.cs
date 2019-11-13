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
        public string Get()
        {

            //return all entity from file
            Models.Filesupport readFile = new Models.Filesupport();
            return readFile.loadJsonFile();
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {
            Models.Products findEntity = new Models.Products();
            string test = findEntity.getEntityUsingId(id);
            return test;

            //ma zwracac produkt o danym id

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
        public void Delete(Guid id)
        {
      
            Models.Filesupport remove = new Models.Filesupport();
            remove.removeSelectValue(id);
            //usuwa produkt
        }
    }
}