using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Library.Service;
using Library_Clean_Architecture.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library_Clean_Architecture.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IGetUserOrdersService _getUserOrdersService;
        public OrdersController(IGetUserOrdersService getUserOrdersService)
        {
            _getUserOrdersService = getUserOrdersService;
        }
        public IActionResult Index()
        {
            long userId = ClaimUtility.GetUserId(User).Value;
            return View(_getUserOrdersService.Execute(userId).Data);
        }
    }
}
