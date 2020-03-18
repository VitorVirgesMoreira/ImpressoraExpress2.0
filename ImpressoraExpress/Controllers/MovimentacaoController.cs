using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Impl;
using BLL.Interfaces;
using DTO;
using ImpressoraExpressMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImpressoraExpressMVC.Controllers
{
    public class MovimentacaoController : BaseController
    {
        private readonly IMovimentacaoService service;

        public MovimentacaoController(IMovimentacaoService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Controlar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Controlar(MovimentacaoViewModel viewModel)
        {

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MovimentacaoViewModel, MovimentacaoDTO>();
            });
            IMapper mapper = configuration.CreateMapper();
            MovimentacaoDTO dto = mapper.Map<MovimentacaoDTO>(viewModel);

            try
            {
                await service.Insert(dto);
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