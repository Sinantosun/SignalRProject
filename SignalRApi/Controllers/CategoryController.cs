﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var value = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetList());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryService.TInsert(new Category()
            {
                CategoryName=createCategoryDto.CategoryName,
                Status=true,
            });
            return Ok("Kategori Eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TgetById(id);
            _categoryService.TDelete(value);
            return Ok("Kategori Silindi.");

        }
        [HttpGet("GetCategoryWithId")]
        public IActionResult GetCategoryWithId(int id)
        {
            var values = _categoryService.TgetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryService.TUpdate(new Category()
            {
                CategoryID=updateCategoryDto.CategoryID,
                CategoryName = updateCategoryDto.CategoryName,
                Status=updateCategoryDto.Status,
            });
            return Ok("Kategori Başarıyla Guncellendi.");
        }


    }
}
