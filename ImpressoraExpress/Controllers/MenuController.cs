using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ImpressoraExpressMVC.Controllers
{
    public class MenuController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Menu()
        {
            return View();
        }
        

        public IActionResult Index()
        {
            return View();
        }
    }
}