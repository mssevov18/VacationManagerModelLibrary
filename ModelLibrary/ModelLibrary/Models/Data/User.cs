using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModelLibrary.Models.Data
{
    [Index(nameof(Username), Name = "IX_Users", IsUnique = true)]
    public partial class User
    {
        public User()
        {
            UsersInTeamsConnections = new HashSet<UsersInTeamsConnection>();
            VacationRequestApprovedBies = new HashSet<VacationRequest>();
            VacationRequestRequesters = new HashSet<VacationRequest>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(15)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(1)]
        public string Role { get; set; }
        [NotMapped]
        public string TextRole
		{
			get
            {
                if (Role == null)
                    return "NULL!";
                switch (Role[0])
                {
                    case 'C':
                    case 'c':
                        return "CEO";
                    case 'D':
                    case 'd':
                        return "Developer";
                    case 'L':
                    case 'l':
                        return "Team Lead";
                }
                return "Unassigned";
            }
		}
        [NotMapped]
        public bool CanEditUsers => Role == "C";
        [NotMapped]
        public bool CanEditTeams => Role == "C" || Role == "L";
        [NotMapped]
        public bool CanEditProjects => Role == "C" || Role == "L";

        public bool IsDeleted { get; set; }

        [InverseProperty(nameof(UsersInTeamsConnection.User))]
        public virtual ICollection<UsersInTeamsConnection> UsersInTeamsConnections { get; set; }
        [InverseProperty(nameof(VacationRequest.ApprovedBy))]
        public virtual ICollection<VacationRequest> VacationRequestApprovedBies { get; set; }
        [InverseProperty(nameof(VacationRequest.Requester))]
        public virtual ICollection<VacationRequest> VacationRequestRequesters { get; set; }
    }
}
