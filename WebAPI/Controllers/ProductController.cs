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
    /**
     * Controller class which controlls the flow of data, by getting them from database and pass it on as JSON data.
     * Class by Oujun Anders Xu
     */

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private DataProcessor _dataProcessor;

        public ProductController(DataProcessor dataprocessor)
        {
            _dataProcessor = dataprocessor;
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
                _dataProcessor.AddProducts(
                    product.Id,
                    product.Title,
                    product.Price,
                    product.Description,
                    product.Category,
                    product.Image,
                    product.Rating.Rate,
                    product.Rating.Count
                ) ;   
            }       
        }

        [HttpGet]
        public JsonResult Get()
        {
            //InsertData();
            List<SingleProduct> cList = _dataProcessor.GetAllProducts<SingleProduct>();
            return new JsonResult(cList.ToArray());
        }

        [HttpPost]
        public JsonResult Post(SingleProduct sp)
        {
            _dataProcessor.AddProducts(
                    sp.Id,
                    sp.Title,
                    sp.Price,
                    sp.Description,
                    sp.Category,
                    sp.Image,
                    sp.Rate,
                    sp.Count
                );
            return new JsonResult("Successfully added!");
        }

        [HttpPut]
        public JsonResult Update(SingleProduct sp) 
        {
            _dataProcessor.UpdateProduct(
                    sp.Id,
                    sp.Title,
                    sp.Price,
                    sp.Description,
                    sp.Category,
                    sp.Image,
                    sp.Rate,
                    sp.Count
            );
            return new JsonResult("Successfully updated");
        }

        [HttpDelete]
        [Route("delete")]
        public JsonResult Delete(SingleProduct sp)
        {
            _dataProcessor.DeleteProduct<SingleProduct>(sp.Id);
            return new JsonResult("Successfully deleted!");
        }

        [HttpGet("{id:int?}")]
        public JsonResult GetProduct(int id)
        {
            List<SingleProduct> result = _dataProcessor.GetProduct<SingleProduct>(id);
            return new JsonResult(result);
        }

        [Route("search")]
        public JsonResult GetSingleProduct(SingleProduct sp)
        {
            List<SingleProduct> result = _dataProcessor.GetProduct<SingleProduct>(sp.Id);
            return new JsonResult(result);
        }

    }
}
