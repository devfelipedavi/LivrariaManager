using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.LM.Business.Models
{
    public class Editora : Entity
    {
        public int CodEditora { get; set; }
        public string Nome { get; set; }
        
        public bool Ativo { get; set; }

        /* EF Relations */
        public Endereco Endereco { get; set; }

        /* EF Relations */
        public IEnumerable<Livro> Livros { get; set; }
    }
}
