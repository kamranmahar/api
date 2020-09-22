using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Services;
namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        public BrandRepository _brandRepository;

        public BrandController(BrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Brand>> GellAll()
        {
            var products = await _brandRepository.GetAllBrand();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Brand>> GetById(int id)
        {
            var product = await _brandRepository.GetById(id);
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult> AddBrand(Brand entity)
        {
            await _brandRepository.AddBrand(entity);
            return Ok(entity);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Brand>> Update(Brand entity, int id)
        {
            await _brandRepository.UpdateBrand(entity, id);
            return Ok(entity);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _brandRepository.RemoveBrand(id);
            return Ok();
        }
    }
}