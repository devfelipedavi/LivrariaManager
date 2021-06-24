using System.Collections.Generic;

namespace DevIO.LM.Business.Models
{
    public class Usuario : Entity
    {
        public int CodUsuario { get; set; }

        public string Nome { get; set; }        
        public string Email { get; set; }

        public bool Ativo { get; set; }

        /* EF Relations */
        public Endereco Endereco { get; set; }
        public Aluguel Aluguel { get; set; }

        /* EF Relations */
        public IEnumerable<Aluguel> Alugueis { get; set; }

    }
}
