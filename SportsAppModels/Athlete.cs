using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFS.SportsApp.Models;

[Table("athletes", Schema = "sports")]
public class Athlete
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    [Column("last_name")]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    [Column("display_name")]
    public string DisplayName { get; set; } = string.Empty;

    [Column("birth_date")]
    public DateOnly? BirthDate { get; set; }

    [Required]
    [MaxLength(3)]
    [Column("nationality")]
    public string Nationality { get; set; } = string.Empty;

    [Column("height_inches")]
    public int? HeightInches { get; set; }

    [Column("weight_lbs")]
    public int? WeightLbs { get; set; }

    // Collection of roster entries for this team
    public virtual ICollection<Roster> Rosters { get; set; } = new List<Roster>();
}
