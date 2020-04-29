using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Database;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [Route("api/private/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DatabaseContext DatabaseContext;
        public ProductController(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        // api/private/product
        [HttpGet]
        public IEnumerable<Product> GetProductAll()
        {
            var data = DatabaseContext.Products.ToList();

            return data;
        }

        // api/private/product
        [HttpGet("insert")]
        public string GetInsert()
        {
            try
            {
                Product item = new Product();
                item.Name = "Test";
                item.Price = 9999;
                DatabaseContext.Products.Add(item);
                DatabaseContext.SaveChanges();

                return "insert successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        // api/private/product/value?
        [HttpGet("{name}")]
        public string GetProductBy(string name)
        {
            return name;
        }

        // api/private/product/value1?/value2?
        [HttpGet("{name}/{phone}")]
        public string GetProductBySome(string name, int phone)
        {
            return $"name : {name}, tel: {phone}";
        }

        // api/private/product/idevdee/value1?/values2?
        [HttpGet("idevdee/{name}/{phone}")]
        public string GetProductByCustomRoute(string name, int phone)
        {
            return $"name : {name}, tel: {phone}";
        }

        // api/private/product/querystring/xxxx?name=xxxx
        [HttpGet("querystring/{phone}")]
        public string GetProductByQueryString([FromQuery]string name, int phone)
        {
            return $"name : {name}, tel: {phone}";
        }
    }
}