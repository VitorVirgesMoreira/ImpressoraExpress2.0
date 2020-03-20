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
        private readonly ICartuchoService carService;
        private readonly IClienteService cliService;
        private readonly IImpressoraService impService;
        private readonly IMovimentacaoService movService;

        public MovimentacaoController(IMovimentacaoService movService,
                                      ICartuchoService carService,
                                      IClienteService cliService,
                                      IImpressoraService impService)
        {
            this.movService = movService;
            this.carService = carService;
            this.cliService = cliService;
            this.impService = impService;
        }

        [HttpGet]
        public async Task<IActionResult> Controlar()
        {

            List<CartuchoDTO> cartuchos = await carService.GetCartuchos();
            List<ClienteDTO> clientes = await cliService.GetClientes();
            List<ImpressoraDTO> impressoras = await impService.GetImpressoras();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CartuchoDTO, CartuchoViewModel>();
                cfg.CreateMap<ClienteDTO, ClienteViewModel>();
                cfg.CreateMap<ImpressoraDTO, ImpressoraViewModel>();
            });

            IMapper mapper = configuration.CreateMapper();

            List<CartuchoViewModel> dadosCartuchos = mapper.Map<List<CartuchoViewModel>>(cartuchos);
            List<ClienteViewModel> dadosClientes = mapper.Map<List<ClienteViewModel>>(clientes);
            List<ImpressoraDTO> dadosImpressoras = mapper.Map<List<ImpressoraDTO>>(impressoras);

            ViewBag.Cartuchos = dadosCartuchos;
            ViewBag.Clientes = dadosClientes;
            ViewBag.Impressoras = dadosImpressoras;


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
                await movService.Insert(dto);
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


        [HttpGet]
        public string CalcularOrcamento(int idCartucho, int idImpressora, int qtdCartucho)
        {


            return "aaa";
        }
    }   
}