using System.ComponentModel.DataAnnotations;

namespace SACC.Models {
    public class Book {

        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [Display(Name = "Título")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O título deve ter entre 3 e 100 caracteres.")]
        public String Title { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [Display(Name = "Descrição")]
        [StringLength(500, MinimumLength = 50, ErrorMessage = "A descrição deve ter entre 50 e 500 caracteres.")]
        public string Description { get; set; }

        [Display(Name = "Imagem da capa")]
        public string? Image { get; set; }

        [Display(Name = "Livro")]
        public string? BookFile { get; set; }
    }
}
