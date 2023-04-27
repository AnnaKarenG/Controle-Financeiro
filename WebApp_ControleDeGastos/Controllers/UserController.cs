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

        public async Task<IActionResult> Index()
        {
            List<User> user = await _user.GetAllUser();
            return View(user);

        }


        public async Task<IActionResult> UpdateUser(int id)
        {

            User user = await _user.GetUserById(id);
            return View(user);
        }

        public async Task<IActionResult> DeleteUser(int id)
        {

            User user = await _user.GetUserById(id);
            return View(user);
        }

        public async Task<IActionResult> DeleteRecordUser(int id)
        {
            await _user.DeleteUser(id);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            await _user.AddUser(user);
            return RedirectToAction("Index");

        }


        [HttpPost]
        public async Task<IActionResult> ChangeUser(User user)
        {

            await _user.UpdateUser(user);
            return RedirectToAction("Index");
        }

    }
}


