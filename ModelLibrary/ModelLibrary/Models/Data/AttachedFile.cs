using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModelLibrary.Models.Data
{
    public partial class AttachedFile
    {
        public AttachedFile()
        {
            VacationRequests = new HashSet<VacationRequest>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Extension { get; set; }
        [Required]
        public byte[] Content { get; set; }
        public DateTime AddedOn { get; set; }
        public bool IsDeleted { get; set; }

        [InverseProperty(nameof(VacationRequest.AttachedFile))]
        public virtual ICollection<VacationRequest> VacationRequests { get; set; }
    }
}
