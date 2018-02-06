using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMS.Models.Info
{
    [Table("CT_VoucherForm", Schema ="VM")]
    public class VoucherFormInfo : BaseInfo
    {



        [Key]
        public Guid VoucherFormId { get; set; }
        [Required]
        public string VoucherFormCode { get; set; }
        [Required]
        public string VoucherFormDescription { get; set; }
        
        [Required]
        public DateTime EffectiveDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        
    }
}
