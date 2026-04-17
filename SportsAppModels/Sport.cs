using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFS.SportsApp.Models
{
    [Table("sports", Schema = "sports")]
    public class Sport
    {
        [Key]
        [Column("sport_id")]
        public int SportId { get; set; }

        [Required]
        [Column("sport_name")]
        [MaxLength(100)]
        public string SportName { get; set; } = null!;

        [Column("category_id")]
        public int CategoryId { get; set; }

        [Column("is_team_sport")]
        public bool? IsTeamSport { get; set; }

        [Column("governing_body")]
        [MaxLength(100)]
        public string? GoverningBody { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        // Navigation property (assumes a SportCategory entity exists)
        public SportCategory? Category { get; set; }
    }
}