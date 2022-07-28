using System.ComponentModel.DataAnnotations;

namespace SACC.ViewModels {
    public class RegisterViewModel {
        [Required(ErrorMessage = "Informe o usuário.")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informe o nome completo.")]
        [Display(Name = "Nome completo")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe o e-mail.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Informe a senha.")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password{ get; set; }

        public string? ReturnUrl { get; set; }
    }
}
