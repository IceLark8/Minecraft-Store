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
using Microsoft.AspNetCore.Http;

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
            List<UserDTO> users = (await _userService.GetAll()).ToList();
            var userId = Int32.Parse(Request.Cookies["user"] ?? "0");
            List<ItemDTO> items = (await _itemService.GetAll()).ToList();
            return View("~/Views/Home/Shop.cshtml", (items, userId));
        }

        public async Task<IActionResult> Cart(int userId)
        {
            if(userId != 0)
            {
                List<CartItemDTO> cartItems = (await _cartItemService.GetAll()).ToList();
                cartItems = cartItems.Where(x => x.UserId == userId).Select(x => x).ToList();
                List<ItemDTO> items = (await _itemService.GetAll()).ToList();
                items = items.Where(x => cartItems.Select(y => y.ItemId).ToList().Contains(x.Id)).Select(x => x).ToList();
                cartItems = cartItems.OrderBy(x => x.ItemId).ToList();
                items = items.OrderBy(x => x.Id).ToList();
                var list = new List<(CartItemDTO, ItemDTO)>() { };
                for(int i = 0; i < cartItems.Count; i++)
                {
                    list.Add((cartItems[i], items[i]));
                }

                return View("~/Views/Home/Cart.cshtml", list);
            }
            else
            {
                return await Index();
            }
        }

        public IActionResult Register()
        {
            UserDTO user = new UserDTO();
            return View("~/Views/Home/Register.cshtml", user);
        }

        public async Task<IActionResult> AddToCart(int userId, int itemId)
        {
            CartItemDTO cartItem = new CartItemDTO() { UserId = userId, ItemId = itemId, Count = 1 };
            await _cartItemService.Add(cartItem);
            return await Index();
        }

        public async Task<IActionResult> RegisterUser(UserDTO newUser)
        {
            await _userService.Add(newUser);

            return await Index();
        }

        public IActionResult Login()
        {
            UserDTO user = new UserDTO();
            return View("~/Views/Home/Login.cshtml", user);
        }

        public async Task<IActionResult> LoginUser(UserDTO newUser)
        {
            var users = await _userService.GetAll();

            UserDTO user = users.Where(x => x.Username == newUser.Username && x.Password == newUser.Password).Select(x => x).FirstOrDefault();
            if (user != null)
            {
                CookieOptions option = new CookieOptions();

                option.Expires = DateTime.Now.AddMinutes(5);
                
                Response.Cookies.Delete("user");

                Response.Cookies.Append("user", user.Id.ToString(), option);

                return await Index();
            }
            else
            {
                return Login();
            }
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
