﻿using E_commerce.Models;
using E_commerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_commerce.Interface;
using MongoDB.Bson;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private  IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;

        }
        [HttpGet]
        public async Task<List<Product>> Get() =>
        await _productService.GetAsync();


        [HttpPost("FilterBy")]

        public async Task<List<Product>> Get([FromBody] RequestItem Req)=>
        await _productService.GetAsync(Req.PageIndex,Req.PageSize);


        [HttpPost("GetById")]
        public async Task<ActionResult<Product>> Get([FromBody] ID id)
        {   
            var product = await _productService.GetWithIdAsync(id.Id);
            return product;
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product newProduct)
        {
            await _productService.CreateAsync(newProduct);

            return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, newProduct);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Product updatedProduct)
        {
            var product = await _productService.GetWithIdAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            updatedProduct.Id = product.Id;

            await _productService.UpdateAsync(id, updatedProduct);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _productService.GetWithIdAsync(id);

            if (product is null)
            {
                return NotFound();
            }


            await _productService.RemoveAsync(id);

            return Ok();
        }






    }
}