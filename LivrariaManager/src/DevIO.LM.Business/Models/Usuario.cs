using System.Collections.Generic;

namespace DevIO.LM.Business.Models
{
    public class Usuario : Entity
    {        
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }

        public bool Ativo { get; set; }

        /* EF Relations */        
        public Aluguel Aluguel { get; set; }

        /* EF Relations */
        public IEnumerable<Aluguel> Alugueis { get; set; }
    }
}
