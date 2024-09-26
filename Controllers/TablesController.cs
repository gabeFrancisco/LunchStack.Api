using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LunchStack.Api.Models.DTOs;
using LunchStack.Api.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LunchStack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TablesController : ControllerBase
    {
        private readonly ITableService _tableService;
        public TablesController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _tableService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TableDTO dto)
        {
            return Ok(await _tableService.CreateAsync(dto));
        }
    }
}