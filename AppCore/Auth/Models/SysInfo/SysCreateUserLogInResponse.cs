using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.SysInfo
{
    public class SysCreateUserLogInResponse
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string StatusCode { get; set; }

        public string StatusDescription { get; set; }
    }
}
