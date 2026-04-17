using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFS.SportsApp.Models
{
    [Table("teams", Schema = "sports")]
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("team_id")]
        public int TeamId { get; set; }

        [Required]
        [Column("league_id")]
        public int LeagueId { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("team_name")]
        public string TeamName { get; set; }

        [MaxLength(50)]
        [Column("short_name")]
        public string? ShortName { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("abbreviation")]
        public string Abbreviation { get; set; }

        [MaxLength(100)]
        [Column("city")]
        public string? City { get; set; }

        [MaxLength(100)]
        [Column("state_province")]
        public string? StateProvince { get; set; }

        [MaxLength(100)]
        [Column("country")]
        public string? Country { get; set; }

        [MaxLength(200)]
        [Column("venue_name")]
        public string? VenueName { get; set; }

        [MaxLength(7)]
        [Column("primary_color", TypeName = "bpchar")]
        public string? PrimaryColor { get; set; }

        [MaxLength(7)]
        [Column("secondary_color", TypeName = "bpchar")]
        public string? SecondaryColor { get; set; }

        [Column("logo_url")]
        public string? LogoUrl { get; set; }

        [Column("founded_year")]
        public int? FoundedYear { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        // Navigation Property for the Foreign Key
        [ForeignKey("LeagueId")]
        public virtual League League { get; set; }

        // Collection of roster entries for this team
        public virtual ICollection<Roster> Rosters { get; set; } = new List<Roster>();
    }
}
