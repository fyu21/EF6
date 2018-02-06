using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.Models.Info
{
    [Table("T_VoucherAllotment", Schema = "VM")]
    public class VoucherAllotmentInfo : BaseInfo
    {
        [Key]
        public Guid VoucherAllotmentId { get; set; }
        [Required]
        public string VoucherAllotmentCode { get; set; }
        [Required]
        public string VoucherAllotmentDescription { get; set; }
        
    }
}
