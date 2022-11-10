using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModelLibrary.Models.Data
{
    [Index(nameof(Name), Name = "IX_Teams", IsUnique = true)]
    public partial class Team
    {
        public Team()
        {
            TeamsWorkingOnProjectsConnections = new HashSet<TeamsWorkingOnProjectsConnection>();
            UsersInTeamsConnections = new HashSet<UsersInTeamsConnection>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        [InverseProperty(nameof(TeamsWorkingOnProjectsConnection.Team))]
        public virtual ICollection<TeamsWorkingOnProjectsConnection> TeamsWorkingOnProjectsConnections { get; set; }
        [InverseProperty(nameof(UsersInTeamsConnection.Team))]
        public virtual ICollection<UsersInTeamsConnection> UsersInTeamsConnections { get; set; }
    }
}
