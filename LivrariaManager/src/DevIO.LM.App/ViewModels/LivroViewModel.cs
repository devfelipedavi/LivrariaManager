using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevIO.LM.App.ViewModels
{
    public class LivroViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Editora")]
        public Guid EditoraId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Autor { get; set; }

        [DisplayName("Lançamento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Lancamento { get; set; }

        [DisplayName("Status")]
        public bool Ativo { get; set; }

        public EditoraViewModel Editora { get; set; }

        public IEnumerable<EditoraViewModel> Editoras { get; set; }
    }
}
