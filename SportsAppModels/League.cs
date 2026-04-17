using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFS.SportsApp.Models
{
    [Table("leagues", Schema = "sports")]
    public class League
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("league_id")]
        public int LeagueId { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("league_name")]
        public string LeagueName { get; set; }

        [Required]
        [Column("sport_id")]
        public int SportId { get; set; }

        [MaxLength(100)]
        [Column("country")]
        public string Country { get; set; }

        [Column("level")]
        public int? Level { get; set; } = 1;

        // Navigation Properties
        [ForeignKey("SportId")]
        public virtual Sport Sport { get; set; }

        public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}
