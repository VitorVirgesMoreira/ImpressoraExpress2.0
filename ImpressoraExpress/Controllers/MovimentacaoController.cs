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
    public class MovimentacaoController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(MovimentacaoViewModel viewModel)
        {

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MovimentacaoViewModel, MovimentacaoDTO>();
            });
            IMapper mapper = configuration.CreateMapper();
            MovimentacaoDTO dto = mapper.Map<MovimentacaoDTO>(viewModel);

            MovimentacaoService svc = new MovimentacaoService();
            try
            {
                await svc.Insert(dto);
                return RedirectToAction("Index", "Movimentacao");
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