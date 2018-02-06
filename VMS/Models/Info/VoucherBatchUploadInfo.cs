using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.Models.Info
{
    [Table("T_VoucherbatchUpload", Schema = "VM")]
    public class VoucherBatchUploadInfo : BaseInfo
    {      
        [Key]
        public Guid VoucherBatchUploadId { get; set; }
        [Required]
        public string BatchNo { get; set; }
        public int? TotalVoucher { get; set; }
        public int? TotalAllotment { get; set; }
        public decimal? TotalFaceValue { get; set; }
        public decimal? TotalVoucherValue { get; set; }
        
    }
}
