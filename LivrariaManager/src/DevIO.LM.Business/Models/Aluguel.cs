using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.LM.Business.Models
{
    public class Aluguel : Entity
    {
        public Guid LivroId { get; set; }
        public Guid UsuarioId { get; set; }

        public DateTime DataAluguel { get; set; }
        public DateTime DataPrevista { get; set; }
        public DateTime DataDevolucao { get; set; }

        public bool Ativo { get; set; }
        
        /* EF Relations */
        //Capacidade de navegação 
        public Livro Livro { get; set; }
        public IEnumerable<Livro> Livros { get; set; }
        public Usuario Usuario { get; set; }
        public IEnumerable<Usuario> Usuarios { get; set; }
    }
}
