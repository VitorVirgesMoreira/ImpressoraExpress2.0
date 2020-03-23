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
        private readonly ICartuchoService _cartuchoService;
        private readonly IClienteService _clienteService;
        private readonly IImpressoraService _impressoraService;
        private readonly IMovimentacaoService _movimentacaoService;

        public MovimentacaoController(IMovimentacaoService movService,
                                      ICartuchoService carService,
                                      IClienteService cliService,
                                      IImpressoraService impService)
        {
            this._movimentacaoService = movService;
            this._cartuchoService = carService;
            this._clienteService = cliService;
            this._impressoraService = impService;
        }

        [HttpGet]
        public async Task<IActionResult> Controlar()
        {
            List<CartuchoDTO> cartuchos = await _cartuchoService.GetData();
            List<ClienteDTO> clientes = await _clienteService.GetData();
            List<ImpressoraDTO> impressoras = await _impressoraService.GetData();

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
                await _movimentacaoService.Insert(dto);
                return RedirectToAction("Index", "Movimentacao");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View();
        }

        public async Task<IActionResult> Index()
        {
            List<MovimentacaoDTO> movimentacoes = await _movimentacaoService.GetData();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MovimentacaoDTO, MovimentacaoViewModel>();
            });

            IMapper mapper = configuration.CreateMapper();
            List<MovimentacaoViewModel> dados = mapper.Map<List<MovimentacaoViewModel>>(movimentacoes);

            return View(dados);
        }

        [HttpGet]
        public string CalcularOrcamento(int idCartucho, int idImpressora, int qtdCartucho)
        {
            double precoCartucho =
            _cartuchoService.GetData().Result.FirstOrDefault(c => c.ID == idCartucho).ValorUnitario;

            double valorTotalCartuchos = precoCartucho * qtdCartucho;

            double precoImpressora =
                _impressoraService.GetData().Result.FirstOrDefault(c => c.ID == idImpressora).Valor;

            double valorOrcamento = valorTotalCartuchos + precoImpressora;

            return valorOrcamento.ToString("C2").Replace("R$", "");
        }
    }   
}