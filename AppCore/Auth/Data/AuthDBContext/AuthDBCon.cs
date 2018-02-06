using App.Core.SysInfo;
using System.Data.Entity;

namespace App.Core.Data.AuthDBContext
{
    public class AuthDBCon : DbContext
    {
        public AuthDBCon() : base("name=AuthDb")
        {

        }

        public DbSet<SysConfig> SysConfigInfoes { get; set; }

        public DbSet<SysUser> SysUserInfoes { get; set; }
    }
}
