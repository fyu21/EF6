using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.Models.Info
{
    [Table("CT_Period", Schema = "VM")]
    public class PeriodInfo : BaseInfo
    {

        [Key]
        public Guid PeriodId { get; set; }
        [Required]
        public string PeriodCode { get; set; }
        [Required]
        public string PeriodDescription { get; set; }
       
        [Required]
        public DateTime EffectiveDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
