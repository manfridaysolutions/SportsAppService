using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MFS.SportsApp.Models
{
    [Table("v_team_rosters", Schema = "sports")]
    public class TeamRoster
    {
        [Column("season_year")]
        public string SeasonYear { get; set; }

        [Column("league_id")]
        public int LeagueId { get; set; }

        [Column("league_name")]
        public string LeagueName { get; set; }

        [Column("team_id")]
        public int TeamId { get; set; }

        [Column("team_name")]
        public string TeamName { get; set; }

        [Column("athlete_id")]
        public int AthleteId { get; set; }

        [Column("player_name")]
        public string PlayerName { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("roster_id")]
        public int RosterId { get; set; }

        [Column("jersey_number")]
        public string JerseyNumber { get; set; }

        [Column("position_id")]
        public int PositionId { get; set; }

        [Column("position_name")]
        public string PositionName { get; set; }

        [Column("pos_abbr")]
        public string PosAbbr { get; set; }

        [Column("is_starting_role")]
        public bool IsStartingRole { get; set; }

        [Column("roster_status")]
        public string RosterStatus { get; set; }

        [Column("nationality")]
        public string Nationality { get; set; }

        [Column("height_inches")]
        public int HeightInches { get; set; }

        [Column("weight_lbs")]
        public int WeightLbs { get; set; }
    }
}
