using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFS.SportsApp.Models;

[Table("athletes", Schema = "sports")]
public class Athlete
{
    [Key]
    [Column("athlete_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AthleteId { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("first_name")]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("last_name")]
    public string LastName { get; set; }

    [Required]
    [MaxLength(200)]
    [Column("display_name")]
    public string DisplayName { get; set; }

    [Column("birth_date")]
    public DateTime? BirthDate { get; set; }

    [MaxLength(100)]
    [Column("nationality")]
    public string? Nationality { get; set; }

    [Column("height_inches")]
    public int? HeightInches { get; set; }

    [Column("weight_lbs")]
    public int? WeightLbs { get; set; }

    [Required]
    [Column("is_active")]
    public bool IsActive { get; set; } = true;
    // Collection of roster entries for this team
    public virtual ICollection<Roster> Rosters { get; set; } = new List<Roster>();
}

