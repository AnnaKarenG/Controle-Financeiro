using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp_ControleDeGastos.Models;
using WebApp_ControleDeGastos.Repository.Interface;
using System.Threading.Tasks;
using System.Linq;

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
            List<Revenue> revenue = await _revenue.GetAllRevenue();
            return View(revenue);

        }


        public async Task<IActionResult> UpdateRevenue(int id)
        {

            Revenue revenue = await _revenue.GetRevenueById(id);
            return View(revenue);
        }

        public async Task<IActionResult> DeleteRevenue(int id)
        {

            Revenue revenue = await _revenue.GetRevenueById(id);
            return View(revenue);
        }

        public async Task<IActionResult> DeleteRecordRevenue(int id)
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