using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SACC.Models {

    [Index(nameof(UserName), IsUnique = true)]
    public class User : IdentityUser {

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string? Image { get; set; }

        [Required]
        [Display(Name = "Data de nascimento")]
        public DateTime Birthday  { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey("PostId")]
        public int PostId { get; set; }
        public IList<Post> Post { get; set; }

    }
}
