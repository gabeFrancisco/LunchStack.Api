using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LunchStack.Api.Context;
using Microsoft.AspNetCore.SignalR;

namespace LunchStack.Api.Hubs
{
    public class AppHub : Hub
    {
        private readonly AppDbContext _context;
        public AppHub(AppDbContext context)
        {
            _context = context;
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}