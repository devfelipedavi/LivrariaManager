﻿using DevIO.LM.Business.Intefaces;
using DevIO.LM.Business.Models;
using DevIO.LM.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace DevIO.LM.Business.Services
{
    public class LivroService : BaseService, ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository,
                              INotificador notificador) : base(notificador)
        {
            _livroRepository = livroRepository;
        }

        public async Task Adicionar(Livro livro)
        {
            if (!ExecutarValidacao(new LivroValidation(), livro)) return;
                        
            await _livroRepository.Adicionar(livro);

        }

        public async Task Atualizar(Livro livro)
        {
            if (!ExecutarValidacao(new LivroValidation(), livro)) return;
                        
            await _livroRepository.Atualizar(livro);
        }

        public async Task Remover(Guid id)
        {
            await _livroRepository.Remover(id);
        }

        public void Dispose()
        {
            _livroRepository?.Dispose();
        }
    }
}
