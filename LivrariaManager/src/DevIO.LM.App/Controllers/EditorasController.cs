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
    //Prefixo de Rota
    [Authorize]
    [Route("Editoras")]
    public class EditorasController : BaseController
    {
        private readonly IEditoraRepository _editoraRepository;
        private readonly IEditoraService _editoraService;
        private readonly IMapper _mapper;

        public EditorasController(IEditoraRepository editoraRepository,
                                      IMapper mapper,
                                      IEditoraService editoraService,
                                      INotificador notificador) : base(notificador)
        {
            _editoraRepository = editoraRepository;
            _mapper = mapper;
            _editoraService = editoraService;
        }

        [AllowAnonymous]
        [Route("lista-de-editoras")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<EditoraViewModel>>(await _editoraRepository.ObterTodos()));
        }

        [AllowAnonymous]
        [Route("dados-da-editora/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var editoraViewModel = await ObterEditora(id);

            if (editoraViewModel == null)
            {
                return NotFound();
            }

            return View(editoraViewModel);
        }

        [Authorize]
        [Route("nova-editora")]       
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [Route("nova-editora")]
        [HttpPost]        
        public async Task<IActionResult> Create(EditoraViewModel editoraViewModel)
        {
            if (!ModelState.IsValid) return View(editoraViewModel);

            var editora = _mapper.Map<Editora>(editoraViewModel);
            await _editoraService.Adicionar(editora);

            if (!OperacaoValida()) return View(editoraViewModel);

            return RedirectToAction("Index");
        }



        [Authorize]
        [Route("editar-editora/{id:guid}")]       
        public async Task<IActionResult> Edit(Guid id)
        {
            var editoraViewModel = await ObterEditoraLivros(id);

            if (editoraViewModel == null)
            {
                return NotFound();
            }

            return View(editoraViewModel);
        }

        [Authorize]
        [Route("editar-editora/{id:guid}")]
        [HttpPost]        
        public async Task<IActionResult> Edit(Guid id, EditoraViewModel editoraViewModel)
        {
            if (id != editoraViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(editoraViewModel);

            var editora = _mapper.Map<Editora>(editoraViewModel);
            await _editoraService.Atualizar(editora);

            if (!OperacaoValida()) return View(await ObterEditoraLivros(id));

            return RedirectToAction("Index");
        }

        [Route("excluir-editora/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var editoraViewModel = await ObterEditora(id);

            if (editoraViewModel == null)
            {
                return NotFound();
            }

            return View(editoraViewModel);
        }
        
        [Route("excluir-editora/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var editora = await ObterEditora(id);

            if (editora == null) return NotFound();

            await _editoraService.Remover(id);

            if (!OperacaoValida()) return View(editora);

            return RedirectToAction("Index");
        }

        private async Task<EditoraViewModel> ObterEditora(Guid id)
        {
            return _mapper.Map<EditoraViewModel>(await _editoraRepository.ObterEditora(id));
        }

        private async Task<EditoraViewModel> ObterEditoraLivros(Guid id)
        {
            return _mapper.Map<EditoraViewModel>(await _editoraRepository.ObterEditoraLivros(id));
        }
    }
}
