using System;

namespace DevIO.LM.Business.Models
{
    public class Livro : Entity
    {
        public Guid EditoraId { get; set; }

        public int CodLivro { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public DateTime Lancamento { get; set; }
        public bool Ativo { get; set; }

        /* EF Relations */
        public Editora Editora { get; set; }
    }
}
