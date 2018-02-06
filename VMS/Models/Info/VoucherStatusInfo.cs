using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.Models.Info
{
    [Table("CT_VoucherStatus", Schema = "VM")]
    public class VoucherStatusInfo : BaseInfo
    {
        


        [Key]
        public Guid VoucherStatusId { get; set; }
        [Required]
        public string VoucherStatusCode { get; set; }
        [Required]
        public string VoucherStatusDescription { get; set; }
        
        [Required]
        [Column(TypeName = "Date")]
        public DateTime EffectiveDate { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }

    }
}
