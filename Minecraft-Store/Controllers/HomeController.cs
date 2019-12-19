using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Minecraft_Store.Models;
using BLL.Services.Interfaces;
using BLL.Services.Impl;
using BLL.DTOs;

namespace Minecraft_Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IFeedbackService _feedbackService;
        private readonly IItemService _itemService;
        private readonly ICartItemService _cartItemService;
        private readonly ICommentService _commentService;


        public HomeController(
            ILogger<HomeController> logger,
            IUserService userService,
            IFeedbackService feedbackService,
            IItemService itemService,
            ICartItemService cartItemService,
            ICommentService commentService)
        {
            _userService = userService;
            _feedbackService = feedbackService;
            _itemService = itemService;
            _cartItemService = cartItemService;
            _commentService = commentService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _itemService.GetAll();
            return View(items);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
