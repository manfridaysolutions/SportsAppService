using MFS.SportsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MFS.SportsApp.Models;

[Table("rosters", Schema = "sports")]
public class Roster
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("athlete_id")]
    public int? AthleteId { get; set; }

    [Column("team_id")]
    public int? TeamId { get; set; }

    [Column("position_id")]
    public int? PositionId { get; set; }

    [MaxLength(5)]
    [Column("jersey_number")]
    public string? JerseyNumber { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }

    [Column("start_date")]
    public DateOnly? StartDate { get; set; }

    [Column("end_date")]
    public DateOnly? EndDate { get; set; }

    // --- Navigation Properties ---

    [ForeignKey(nameof(AthleteId))]
    public virtual Athlete? Athlete { get; set; }

    [ForeignKey(nameof(TeamId))]
    public virtual Team? Team { get; set; }

    //[ForeignKey(nameof(PositionId))]
    //public virtual Position? Position { get; set; }
}

