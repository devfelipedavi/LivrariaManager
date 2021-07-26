using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevIO.LM.App.ViewModels
{
    public class AluguelViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Livro")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid LivroId { get; set; }

        [DisplayName("Usuário")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid UsuarioId { get; set; }


        [DisplayName("Data de Emprestimo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataAluguel { get; set; }

        [DisplayName("Data de Devolução")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataDevolucao { get; set; }

        [DisplayName("Status")]
        public bool Ativo { get; set; }   

        public IEnumerable<LivroViewModel> Livros { get; set; }       
        public IEnumerable<UsuarioViewModel> Usuarios { get; set; }
    }
}
