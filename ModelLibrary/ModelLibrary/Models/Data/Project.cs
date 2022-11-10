using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModelLibrary.Models.Data
{
    [Index(nameof(Name), Name = "IX_Projects", IsUnique = true)]
    public partial class Project
    {
        public Project()
        {
            TeamsWorkingOnProjectsConnections = new HashSet<TeamsWorkingOnProjectsConnection>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        [InverseProperty(nameof(TeamsWorkingOnProjectsConnection.Project))]
        public virtual ICollection<TeamsWorkingOnProjectsConnection> TeamsWorkingOnProjectsConnections { get; set; }
    }
}
