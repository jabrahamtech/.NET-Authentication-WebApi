using jabr888.Data;
using jabr888.Dto;
using jabr888.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace jabr888.Controllers
{   
    [Route("api")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IWebAPIRepo _repository;
        public HomeController(IWebAPIRepo repository)
        {
            _repository = repository;
        }
        //Post: User
        [HttpPost("Register")]
        public ActionResult<UserInputDto> AddUser(UserInputDto User)
        {
            Users u = _repository.GetUserByName(User.UserName);
            IEnumerable<Users> Users = _repository.GetAllUsers();
            if (Users.Contains(u))
            {
                return Ok("Username not available.");
            }
            Users NewUser = new Users { UserName = User.UserName, Password = User.Password, Address = User.Address };
            Users addedUser = _repository.AddUser(NewUser);
            return Ok("User successfully registered.");
        }

        //Get: Version(Authorized)
        [Authorize(AuthenticationSchemes = "MyAuthentication")]
        [Authorize(Policy = "UserOnly")]
        [HttpGet("GetVersionA")]
        public ActionResult<UserInputDto> ViewVersion()
        {
            return Ok("v1");
        }

        //Post: Purchase Item
        [Authorize(AuthenticationSchemes = "MyAuthentication")]
        [Authorize(Policy = "UserOnly")]
        [HttpPost("PurchaseItem")]
        public ActionResult<OrdersOutputDto> AddOrder(OrdersInputDto Order)
        {
            ClaimsIdentity ci = HttpContext.User.Identities.FirstOrDefault();
            Claim c = ci.FindFirst("userName");
            string name = c.Value;
            Users u = _repository.GetUserByName(name);
            Orders theUser = new Orders { UserName = u.UserName, ProductID = Order.ProductID, Quantity = Order.Quantity };
            Orders addedOrder = _repository.AddOrder(theUser);
            return Ok(addedOrder);
        }

        //Get: Purchase Item ID
        [Authorize(AuthenticationSchemes = "MyAuthentication")]
        [Authorize(Policy = "UserOnly")]
        [HttpGet("PurchaseSingleItem/{item}")]
        public ActionResult<OrdersOutputDto> PurchaseItem(int item)
        {
            ClaimsIdentity ci = HttpContext.User.Identities.FirstOrDefault();
            Claim c = ci.FindFirst("userName");
            string name = c.Value;
            Users u = _repository.GetUserByName(name);
            Orders theUser = new Orders { UserName = u.UserName, ProductID = item, Quantity = 1 };
            Orders addedOrder = _repository.AddOrder(theUser);
            return Ok(addedOrder);
        }
    }
}
