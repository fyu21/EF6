using System;
using System.ComponentModel.DataAnnotations;

namespace App.Core.SysInfo
{
    public class SysUserLogInResponse
    {
        public Guid UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        public string StatusCode { get; set; }

        public string StatusDescription { get; set; }
    }
}
