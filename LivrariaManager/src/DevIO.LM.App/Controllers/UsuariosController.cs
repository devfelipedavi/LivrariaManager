using AutoMapper;
using DevIO.LM.App.ViewModels;
using DevIO.LM.Business.Intefaces;
using DevIO.LM.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.LM.App.Controllers
{
    [Authorize]
    [Route("Usuarios")]
    public class UsuariosController : BaseController
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioRepository usuarioRepository,
                                  IMapper mapper,
                                  IUsuarioService usuarioService,
                                  INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _usuarioService = usuarioService;
        }

        [AllowAnonymous]
        [Route("lista-de-usuarios")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<UsuarioViewModel>>(await _usuarioRepository.ObterTodos()));
        }

        [AllowAnonymous]
        [Route("dados-do-usuario/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var usuarioViewModel = await ObterUsuario(id);

            if (usuarioViewModel == null)
            {
                return NotFound();
            }

            return View(usuarioViewModel);
        }

        [Route("novo-usuario")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-usuario")]
        [HttpPost]
        public async Task<IActionResult> Create (UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return View(usuarioViewModel);

            var usuario = _mapper.Map<Usuario>(usuarioViewModel);
            await _usuarioService.Adicionar(usuario);

            if (!OperacaoValida()) return View(usuarioViewModel);

            return RedirectToAction("Index");
        }
        
        [Route("editar-usuario/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var usuarioViewModel = await ObterUsuarioAlugueis(id);

            if (usuarioViewModel == null)
            {
                return NotFound();
            }

            return View(usuarioViewModel);
        }

        [Route("editar-usuario/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, UsuarioViewModel usuarioViewModel)
        {
            if (id != usuarioViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(usuarioViewModel);

            var usuario = _mapper.Map<Usuario>(usuarioViewModel);
            await _usuarioService.Atualizar(usuario);

            if (!OperacaoValida()) return View(await ObterUsuarioAlugueis(id));

            return RedirectToAction("Index");
        }

        [Route("excluir-usuario/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var usuarioViewModel = await ObterUsuario(id);

            if (usuarioViewModel == null)
            {
                return NotFound();
            }

            return View(usuarioViewModel);
        }

        [Route("excluir-usuario/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var usuario = await ObterUsuario(id);

            if (usuario == null) return NotFound();

            await _usuarioService.Remover(id);

            if (!OperacaoValida()) return View(usuario);

            return RedirectToAction("Index");
        }

        
        private async Task<UsuarioViewModel> ObterUsuario(Guid id)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.ObterUsuario(id));
        }

        private async Task<UsuarioViewModel> ObterUsuarioAlugueis(Guid id)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.ObterUsuarioAlugueis(id));
        }
    }
}
