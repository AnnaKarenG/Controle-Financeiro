using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp_ControleDeGastos.Models;
using WebApp_ControleDeGastos.Repository.Interface;
using System.Threading.Tasks;
using System.Linq;

namespace WebApp_ControleDeGastos.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {

            _user = user;
        }

        public IActionResult Index()
        {
            List<User> user = _user.GetAllUser();
            return View(user);

        }

        public async Task<IActionResult> LoginUser()
        {
            return View("Login");

        }

        public async Task<IActionResult> ContaUser(User user)
        {

            return View("ContaUser", user);

        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            List<User> users = _user.GetAllUser();

            foreach (User item in users)
            {
                if (item.Email == user.Email && item.Password == user.Password)
                {
                    return RedirectToAction("ContaUser", item);
                }
            }

            return BadRequest();

        }

        public async Task<IActionResult> UpdateUser(long id)
        {

            User user = _user.GetUserById(id);
            return View(user);
        }

        public async Task<IActionResult> DeleteUser(long id)
        {

            User user = _user.GetUserById(id);
            return View(user);
        }

        public async Task<IActionResult> DeleteRecordUser(int id)
        {
            await _user.DeleteUser(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddUser()
        {
            return View("AddUser");

        }

        [HttpPost]
        public async Task<IActionResult> ToAddUser(User user)
        {
            await _user.AddUser(user);
            return RedirectToAction("LoginUser");

        }


        [HttpPost]
        public async Task<IActionResult> ChangeUser(User user)
        {

            await _user.UpdateUser(user);
            return RedirectToAction("Index");
        }

    }
}


