using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMS.Models.Info
{
    [Table("CT_ExternalSystem", Schema = "VM")]
    public class ExternalSystemInfo : BaseInfo
    {
        [Key]
        public Guid ExternalSystemId { get; set; }
        [Required]
        public string ExternalSystemCode { get; set; }
        [Required]
        public string ExternalSystemDescription { get; set; }
        
    }
}
