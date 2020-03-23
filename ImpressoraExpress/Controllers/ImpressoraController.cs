﻿using System;
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
    public class ImpressoraController : BaseController
    {
        private readonly IImpressoraService service;
        public ImpressoraController(IImpressoraService service)
        {
            this.service = service;
        }

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

            try
            {
                await service.Insert(dto);
                return RedirectToAction("Index", "Impressora");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View();
        }

        public async Task<IActionResult> Index()
        {
            List<ImpressoraDTO> impressoras = await service.GetData();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ImpressoraDTO, ImpressoraViewModel>();
            });

            IMapper mapper = configuration.CreateMapper();
            List<ImpressoraViewModel> dados = mapper.Map<List<ImpressoraViewModel>>(impressoras);

            return View(dados);
        }
    }
}