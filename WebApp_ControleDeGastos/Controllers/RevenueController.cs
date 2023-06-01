using System.Collections.Generic;
using WebApp_ControleDeGastos.Models;
using WebApp_ControleDeGastos.Repository.Interface;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApp_ControleDeGastos.Controllers
{
    public class RevenueController : Controller
    {
        private readonly IRevenue _revenue;
        public RevenueController(IRevenue revenue)
        {

            _revenue = revenue;
        }

        public async Task<IActionResult> Index()
        {
            List<Revenue> revenue = _revenue.GetAllRevenue();
            return View(revenue);

        }


        public async Task<IActionResult> UpdateRevenue(long id)
        {

            Revenue revenue =  _revenue.GetRevenueById(id);
            return View(revenue);
        }

        public async Task<IActionResult> DeleteRevenue(long id)
        {

            Revenue revenue = _revenue.GetRevenueById(id);
            return View(revenue);
        }

        public async Task<IActionResult> DeleteRecordRevenue(long id)
        {
            await _revenue.DeleteRevenue(id);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> ToAddRevenue(Revenue revenue)
        {
           await _revenue.AddRevenue(revenue);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> AddRevenue(Revenue revenue)
        {
            return View();

        }


        [HttpPost]
        public async Task<IActionResult> ChangeRevenue(Revenue revenue)
        {

            await _revenue.UpdateRevenue(revenue);
            return RedirectToAction("Index");
        }

    }
}