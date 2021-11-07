using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OmegaPointSimpleAPI.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OmegaPointSimpleAPI.Data.BusinessLogic;
using Microsoft.Extensions.Configuration;

namespace OmegaPointSimpleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            string sqlDataSource = _configuration.GetConnectionString("ProductDB");
            return sqlDataSource;
        }


        private List<ProductModel> NewData()
        {
            //Get json as string
            string json = new WebClient().DownloadString("https://kodtest.azurewebsites.net/api/products?code=MWZOJunmBNEPDGxldyIKSplsqq/8Sv4c6KvgZ1vyh4Z9wCaw6rqJIA==");
            //Convert string to a list containing all the json-data.
            List<ProductModel> jsonData = JsonConvert.DeserializeObject<List<ProductModel>>(json);
            return jsonData;
        }

        private void InsertData()
        {
            List<ProductModel> products = NewData();
            foreach(var product in products)
            {
                DataProcessor.AddProducts(
                    product.Id,
                    product.Title,
                    product.Price,
                    product.Description,
                    product.Category,
                    product.Image,
                    product.Rating.Rate,
                    product.Rating.Count,
                    GetConnectionString()
                ) ;   
            }       
        }

        [HttpGet]
        public JsonResult Get()
        {
            InsertData();
            List<SingleProduct> cList = DataProcessor.GetAllProducts<SingleProduct>(GetConnectionString());
            return new JsonResult(cList.ToArray());
        }

        [HttpPost]
        public JsonResult Post(SingleProduct sp)
        {
            DataProcessor.AddProducts(
                    sp.Id,
                    sp.Title,
                    sp.Price,
                    sp.Description,
                    sp.Category,
                    sp.Image,
                    sp.Rate,
                    sp.Count,
                    GetConnectionString()
                );
            return new JsonResult("Successfully added!");
        }

        [HttpDelete]
        public JsonResult Delete(ProductModel pm)
        {
            DataProcessor.DeleteProduct<SingleProduct>(pm.Id, GetConnectionString());
            return new JsonResult("Successfully deleted!");
        }

        [Route("GetProduct")]
        public JsonResult GetProduct(ProductModel pm)
        {
            List<SingleProduct> result = DataProcessor.GetProduct<SingleProduct>(pm.Id, GetConnectionString());
            return new JsonResult(result);
        }
    }
}
