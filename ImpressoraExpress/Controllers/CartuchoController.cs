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
    public class CartuchoController : Controller
    {
        private readonly ICartuchoService service;

        public CartuchoController(ICartuchoService service)
        {
            this.service = service;
        }
        //Controllers
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

        public IActionResult Index()
        {
            return View();
        }
    }
}