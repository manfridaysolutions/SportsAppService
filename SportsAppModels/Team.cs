using MFS.SportsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MFS.SportsApp.Models;

[Table("teams", Schema = "sports")]
public class Team
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("league_id")]
    public int? LeagueId { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(10)]
    [Column("abbreviation")]
    public string Abbreviation { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    [Column("city")]
    public string City { get; set; } = string.Empty;

    // Collection of roster entries for this team
    public virtual ICollection<Roster> Rosters { get; set; } = new List<Roster>();
}
