using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LunchStack.Api.Models.DTOs;
using LunchStack.Api.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LunchStack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoryService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDTO dto)
        {
            return Ok(await _categoryService.CreateAsync(dto));
        }
    }
}