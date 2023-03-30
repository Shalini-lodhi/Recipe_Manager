using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The title is too long, try a shorter one (50 characters limit)")]
        public string Title { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "The description is too long, try a shorter one (1000 characters limit)")]
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
