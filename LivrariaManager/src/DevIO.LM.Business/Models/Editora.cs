using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.LM.Business.Models
{
    public class Editora : Entity
    {
        public string Nome { get; set; }

        public string Estado { get; set; }
        public string Cidade { get; set; }

        public bool Ativo { get; set; }

        /* EF Relations */
        public IEnumerable<Livro> Livros { get; set; }
    }
}
