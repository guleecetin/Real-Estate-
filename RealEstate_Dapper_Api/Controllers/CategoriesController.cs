﻿using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryRepository.GetAllCategoryAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult>CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryRepository.CreateCategory(createCategoryDto);
            return Ok("Kategori başarılı şekilde eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult>DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
            return Ok("Kategori başarılı şekilde silindi.");
        }
        [HttpPut]
        public async Task<IActionResult>UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryRepository.UpdateCategory(updateCategoryDto);
            return Ok("Kategori başarılı şekilde güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetCategory(int id)
        {
            var value =  await _categoryRepository.GetCategory(id);
            return Ok(value);
        }

    }
}
