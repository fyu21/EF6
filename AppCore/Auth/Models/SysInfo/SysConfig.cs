using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.SysInfo
{
    [Table("SysConfig", Schema = "Auth")]
    public class SysConfig
    {
        [Key]
        public Guid ConfigurationID { get; set; }

        public string ConfigurationName { get; set; }

        [Required]
        public string ConfigurationValue { get; set; }
    }
}
