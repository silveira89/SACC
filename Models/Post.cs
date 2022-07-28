using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SACC.Models {
    public class Post {

        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Conteúdo")]
        public string Contents { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public User User { get; set; }

        
    }
}
