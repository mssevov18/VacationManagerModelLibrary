using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModelLibrary.Models.Data
{
    public partial class VacationRequest
    {
        [Key]
        public int Id { get; set; }
        public int RequesterId { get; set; }
        [Required]
        [StringLength(1)]
        public string Type { get; set; }
        [Column(TypeName = "date")]
        public DateTime FromDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime ToDate { get; set; }
        public DateTime SubmittedOn { get; set; }
        public int? ApprovedById { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public int? AttachedFileId { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(ApprovedById))]
        [InverseProperty(nameof(User.VacationRequestApprovedBies))]
        public virtual User ApprovedBy { get; set; }
        [ForeignKey(nameof(AttachedFileId))]
        [InverseProperty("VacationRequests")]
        public virtual AttachedFile AttachedFile { get; set; }
        [ForeignKey(nameof(RequesterId))]
        [InverseProperty(nameof(User.VacationRequestRequesters))]
        public virtual User Requester { get; set; }
    }
}
