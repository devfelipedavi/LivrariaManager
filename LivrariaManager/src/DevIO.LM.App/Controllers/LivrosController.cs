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
    [Route("livros")]
    public class LivrosController : BaseController
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IEditoraRepository _editoraRepository;
        private readonly ILivroService _livroService;
        private readonly IMapper _mapper;

        public LivrosController(ILivroRepository livroRepository,
                                  IEditoraRepository editoraRepository,
                                  IMapper mapper,
                                  ILivroService livroService,
                                  INotificador notificador) : base(notificador)
        {
            _livroRepository = livroRepository;
            _editoraRepository = editoraRepository;
            _mapper = mapper;
            _livroService = livroService;
        }

        [AllowAnonymous]
        [Route("lista-de-livros")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<LivroViewModel>>(await _livroRepository.ObterLivrosEditoras()));
        }

        [AllowAnonymous]
        [Route("dados-do-livro/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var livroViewModel = await ObterLivro(id);

            if (livroViewModel == null)
            {
                return NotFound();
            }

            return View(livroViewModel);
        }

        [Authorize]
        [Route("novo-livro")]        
        public async Task<IActionResult> Create()
        {
            var livroViewModel = await PopularEditoras(new LivroViewModel());

            return View(livroViewModel);
        }

        [Authorize]
        [Route("novo-livro")]
        [HttpPost]
        public async Task<IActionResult> Create(LivroViewModel livroViewModel)
        {
            livroViewModel = await PopularEditoras(livroViewModel);
            if (!ModelState.IsValid) return View(livroViewModel);

            await _livroService.Adicionar(_mapper.Map<Livro>(livroViewModel));

            if (!OperacaoValida()) return View(livroViewModel);

            return RedirectToAction("Index");
        }

        [Authorize]
        [Route("editar-livro/{id:guid}")]        
        public async Task<IActionResult> Edit(Guid id)
        {
            var livroViewModel = await ObterLivro(id);

            if (livroViewModel == null)
            {
                return NotFound();
            }

            return View(livroViewModel);
        }

        [Authorize]
        [Route("editar-livro/{id:guid}")]     
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, LivroViewModel livroViewModel)
        {
            if (id != livroViewModel.Id) return NotFound();

            var livroAtualizacao = await ObterLivro(id);
            livroViewModel.Editora = livroAtualizacao.Editora;
            if (!ModelState.IsValid) return View(livroViewModel);

            livroAtualizacao.Nome = livroViewModel.Nome;
            livroAtualizacao.Autor = livroViewModel.Autor;
            livroAtualizacao.Lancamento = livroViewModel.Lancamento;

            await _livroService.Atualizar(_mapper.Map<Livro>(livroAtualizacao));

            if (!OperacaoValida()) return View(livroViewModel);

            return RedirectToAction("Index");
        }

        [Authorize]
        [Route("excluir-livro/{id:guid}")]        
        public async Task<IActionResult> Delete(Guid id)
        {
            var livro = await ObterLivro(id);

            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        [Authorize]
        [Route("excluir-livro/{id:guid}")]
        [HttpPost, ActionName("Delete")]        
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var livro = await ObterLivro(id);

            if (livro == null)
            {
                return NotFound();
            }

            await _livroService.Remover(id);

            if (!OperacaoValida()) return View(livro);

            TempData["Sucesso"] = "Livro excluido com sucesso!";

            return RedirectToAction("Index");
        }

        private async Task<LivroViewModel> ObterLivro(Guid id)
        {
            var livro = _mapper.Map<LivroViewModel>(await _livroRepository.ObterLivroEditora(id));
            livro.Editoras = _mapper.Map<IEnumerable<EditoraViewModel>>(await _editoraRepository.ObterTodos());
            return livro;
        }

        private async Task<LivroViewModel> PopularEditoras(LivroViewModel livro)
        {
            livro.Editoras = _mapper.Map<IEnumerable<EditoraViewModel>>(await _editoraRepository.ObterTodos());
            return livro;
        }
    }
}
