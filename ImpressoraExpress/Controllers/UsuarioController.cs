using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Impl;
using BLL.Interfaces;
using DTO;
using ImpressoraExpressMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ImpressoraExpressMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService service;

        public UsuarioController(IUsuarioService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(UsuarioViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioViewModel, UsuarioDTO>();
            });
            IMapper mapper = configuration.CreateMapper();
            UsuarioDTO dto = mapper.Map<UsuarioDTO>(viewModel);

            try
            {
                await service.Create(dto);
                return RedirectToAction("Login", "Usuario");
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
        public async Task<IActionResult> Login() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, bool isPersistent)
        {
            try
            {
                UsuarioDTO usuario = await service.Authenticate(email, password);
                if (isPersistent)
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Append(email, password, options);
                }
                else
                {
                    Response.Cookies.Append(email, password);
                }
                return RedirectToAction("Controlar", "Movimentacao");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View();

        }
    }
}