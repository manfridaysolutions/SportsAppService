using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFS.SportsApp.Models
{
    [Table("sport_categories", Schema = "sports")]
    public class SportCategory
    {
        [Key]
        [Column("category_id")]
        public int CategoryId { get; set; }

        [Required]
        [Column("category_name")]
        [MaxLength(100)]
        public string CategoryName { get; set; } = null!;

        [Column("description")]
        public string? Description { get; set; }

        // Navigation property to related sports
        public ICollection<Sport> Sports { get; set; } = new List<Sport>();
    }
}