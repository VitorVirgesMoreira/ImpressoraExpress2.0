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
        private readonly ICartuchoService _carService;
        private readonly IClienteService _cliService;
        private readonly IImpressoraService _impService;
        private readonly IMovimentacaoService _movService;

        public MovimentacaoController(IMovimentacaoService movService,
                                      ICartuchoService carService,
                                      IClienteService cliService,
                                      IImpressoraService impService)
        {
            this._movService = movService;
            this._carService = carService;
            this._cliService = cliService;
            this._impService = impService;
        }

        [HttpGet]
        public async Task<IActionResult> Controlar()
        {

            List<CartuchoDTO> cartuchos = await _carService.GetCartuchos();
            List<ClienteDTO> clientes = await _cliService.GetClientes();
            List<ImpressoraDTO> impressoras = await _impService.GetImpressoras();

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
                await _movService.Insert(dto);
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
            double precoCartucho =
            _carService.GetData().Result.FirstOrDefault(c => c.ID == idCartucho).ValorUnitario;

            double valorTotalCartuchos = precoCartucho * qtdCartucho;

            double precoImpressora =
                _impService.GetData().Result.FirstOrDefault(c => c.ID == idImpressora).Valor;

            double valorOrcamento = valorTotalCartuchos + precoImpressora;

            return valorOrcamento.ToString("C2");
        }
    }   
}