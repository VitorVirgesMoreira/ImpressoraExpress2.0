using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Impl;
using DTO;
using ImpressoraExpressMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImpressoraExpressMVC.Controllers
{
    public class ImpressoraController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(ImpressoraViewModel viewModel)
        {

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ImpressoraViewModel, ImpressoraDTO>();
            });
            IMapper mapper = configuration.CreateMapper();
            ImpressoraDTO dto = mapper.Map<ImpressoraDTO>(viewModel);

            ImpressoraService svc = new ImpressoraService();
            try
            {
                await svc.Insert(dto);
                return RedirectToAction("Index", "Impressora");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}