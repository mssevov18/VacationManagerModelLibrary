using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModelLibrary.Models.Data
{
    [Table("TeamsWorkingOnProjectsConnection")]
    [Index(nameof(TeamId), nameof(ProjectId), Name = "IX_TeamsWorkingOnProjectsConnection", IsUnique = true)]
    public partial class TeamsWorkingOnProjectsConnection
    {
        [Key]
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int ProjectId { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(ProjectId))]
        [InverseProperty("TeamsWorkingOnProjectsConnections")]
        public virtual Project Project { get; set; }
        [ForeignKey(nameof(TeamId))]
        [InverseProperty("TeamsWorkingOnProjectsConnections")]
        public virtual Team Team { get; set; }
    }
}
