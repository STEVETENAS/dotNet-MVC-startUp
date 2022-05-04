using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required,MinLength(3)]
        public string Name { get; set; }
        [Display(Name = "Display order"), Required(ErrorMessage = "Value can't be null!"), Range(1,100)]
        public int DisplayOrder { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
