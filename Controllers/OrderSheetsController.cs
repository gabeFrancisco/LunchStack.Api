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
    public class OrderSheetsController : ControllerBase
    {
        private readonly IOrderSheetService _orderSheetService;
        public OrderSheetsController(IOrderSheetService orderSheetService)
        {
            _orderSheetService = orderSheetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderSheetService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderSheetDTO dto)
        {
            return Ok(await _orderSheetService.CreateAsync(dto));
        }
    }
}