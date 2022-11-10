using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModelLibrary.Models.Data
{
    [Table("UsersInTeamsConnection")]
    [Index(nameof(TeamId), nameof(UserId), Name = "IX_UsersInTeamsConnection", IsUnique = true)]
    public partial class UsersInTeamsConnection
    {
        [Key]
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(TeamId))]
        [InverseProperty("UsersInTeamsConnections")]
        public virtual Team Team { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("UsersInTeamsConnections")]
        public virtual User User { get; set; }
    }
}
