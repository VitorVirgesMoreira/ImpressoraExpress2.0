﻿using System;
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
    public class ClienteController : Controller
    {
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }
        public async Task<IActionResult> Cadastrar(ClienteViewModel viewModel)
        {

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClienteViewModel, ClienteDTO>();
            });
            IMapper mapper = configuration.CreateMapper();
            ClienteDTO dto = mapper.Map<ClienteDTO>(viewModel);

            ClienteService svc = new ClienteService();
            try
            {
                await svc.Insert(dto);
                return RedirectToAction("Index", "Cliente");
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