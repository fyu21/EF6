using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMS.Models.Info
{
    [Table("T_Voucher",Schema ="VM")]    
    public class VoucherInfo : BaseInfo
    {
        [Key]        
        public Guid VoucherId { get; set; }
        [Required]
        [MaxLength(40)]
        public string VoucherNo { get; set; }
        public Guid? VoucherFormId { get; set; }

        [ForeignKey("ExternalSystem")]
        public Guid? VoucherIssuanceSystemId { get; set; }

        [Required]
        public Guid VoucherStatusId { get; set; }
        public string VoucherTypeCode { get; set; }
        public decimal? VoucherValue { get; set; }
        public decimal? FaceValue { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public bool? IsInclusiveGstFlag { get; set; }
        public DateTime? ValidityStartTime { get; set; }
        public DateTime? ValidityEndTime { get; set; }

        [ForeignKey("Period")]
        public Guid? ValidityPeriodId { get; set; }

        public int? ValidityPeriod { get; set; }
        public bool? IsInterDepartmentChargeFlag { get; set; }
        public string PromotionCode { get; set; }
        public string PromotionDescription { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string ChartOfAccountNo { get; set; }
        public string CostCentreCode { get; set; }
        public string GlCode { get; set; }
        public Guid? VoucherAllotmentId { get; set; }
        public string VoucherAllotmentRefNo { get; set; }
        public Guid? VoucherBatchUploadId { get; set; }
        [Required]
        public DateTime LastTrxnCreatedTime { get; set; }
        [Required]
        public string LastExternalSystemTrxnRefId { get; set; }
        
        public string MemberNo { get; set; }
        public string MemberFullName { get; set; }
        public string Remarks { get; set; }

        public virtual VoucherFormInfo VoucherForm { get; set; }
        public virtual VoucherStatusInfo VoucherStatus { get; set; }
        public virtual ExternalSystemInfo ExternalSystem { get; set; }
        public virtual VoucherAllotmentInfo VoucherAllotment { get; set; }
        public virtual VoucherBatchUploadInfo VoucherBatchUpload { get; set; }
        public virtual PeriodInfo Period { get; set; }
    }
}
