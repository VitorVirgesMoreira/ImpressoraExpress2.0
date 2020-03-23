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
    public class CartuchoController : BaseController
    {
        private readonly ICartuchoService service;
        public CartuchoController(ICartuchoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CartuchoViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CartuchoViewModel, CartuchoDTO>();
            });
            IMapper mapper = configuration.CreateMapper();
            CartuchoDTO dto = mapper.Map<CartuchoDTO>(viewModel);

            try
            {
                await service.Insert(dto);
                return RedirectToAction("Index", "Cartucho");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View();
        }

        public async Task<IActionResult> Index()
        {
            List<CartuchoDTO> cartuchos = await service.GetData();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CartuchoDTO, CartuchoViewModel>();
            });

            IMapper mapper = configuration.CreateMapper();
            List<CartuchoViewModel> dados = mapper.Map<List<CartuchoViewModel>>(cartuchos);

            return View(dados);
        }
    }
}