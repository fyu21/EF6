using System;
using System.ComponentModel.DataAnnotations;

namespace VMS.Models.Info
{
    public class BaseInfo
    {
        [Required]
        public short ActiveStatus { get; set; }
        [Required]
        public Guid CreatedBy { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }
        [Required]
        public Guid ModifiedBy { get; set; }
        [Required]
        public DateTime ModifiedTime { get; set; }
    }
}
