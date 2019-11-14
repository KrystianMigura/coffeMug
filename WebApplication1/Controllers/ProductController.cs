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

            Models.Filesupport readFile = new Models.Filesupport();
            return readFile.loadJsonFile();
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {
            Models.Products findEntity = new Models.Products();
            string product = findEntity.getEntityUsingId(id);
            return product;

        }

        [HttpPost]
        public string Post([FromBody] Models.model model )
        {
            return model.ProductCreateInputModel();           
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Models.Filesupport mod)
        {
            Models.Filesupport update = new Models.Filesupport();
            update.ProductUpdateInputModel(id, mod);
            
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            Models.Filesupport remove = new Models.Filesupport();
            remove.removeSelectValue(id);
        }
    }
}