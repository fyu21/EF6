using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.SysInfo
{
    [Table("SysUser", Schema = "Auth")]
    public class SysUser
    {
        [Key]
        public Guid UserId { get; set; }

        
        [Required]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        public byte[] Password { get; set; }

        [Required]
        public string PasswordSalt { get; set; }

        [Required]
        public bool ActiveStatus { get; set; }

        [Required]
        public DateTime CreatedDateTime { get; set; }

        [Required]
        public DateTime ModifiedDateTime { get; set; }

        [Required]
        public Guid CreatedById { get; set; }

        [Required]
        public Guid ModifiedById { get; set; }
    }
}
