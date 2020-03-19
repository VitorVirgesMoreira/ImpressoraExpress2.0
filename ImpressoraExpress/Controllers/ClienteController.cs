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
    public class ClienteController : BaseController
    {
        private readonly IClienteService service;
        public ClienteController(IClienteService service)
        {
            this.service = service;
        }


        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(ClienteViewModel viewModel)
        {

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClienteViewModel, ClienteDTO>();
            });
            IMapper mapper = configuration.CreateMapper();
            ClienteDTO dto = mapper.Map<ClienteDTO>(viewModel);

            try
            {
                await service.Insert(dto);
                return RedirectToAction("Index", "Cliente");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View();
        }
        public async Task<IActionResult> Index()
        {
            List<ClienteDTO> clientes = await service.GetData();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClienteDTO, ClienteViewModel>();
            });

            IMapper mapper = configuration.CreateMapper();
            List<ClienteViewModel> dados = mapper.Map<List<ClienteViewModel>>(clientes);

            return View(dados);

        }
    }
}