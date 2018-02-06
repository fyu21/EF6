using System;
using System.ComponentModel.DataAnnotations;

namespace App.Core.SysInfo
{
    public class SysUserLogIn
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string CreatedBy { get; set; }
    }
}
