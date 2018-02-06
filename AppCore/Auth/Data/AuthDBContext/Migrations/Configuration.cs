namespace App.Core.Data.AuthDBContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SysInfo;
    using System.Security.Cryptography;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<App.Core.Data.AuthDBContext.AuthDBCon>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(App.Core.Data.AuthDBContext.AuthDBCon context)
        {
            Guid defaultUID = new Guid("DAD2C21E-CD39-46FE-A1E3-C61CD3B66362");
            Byte[] PasswordSalt = Encoding.ASCII.GetBytes("12345678");
            byte[] password = Encoding.ASCII.GetBytes("12345678");
            SysUser sysUser;
            using (HMACSHA512 hmac = new HMACSHA512(PasswordSalt))
            {
                sysUser = new SysUser
                {
                    UserId = defaultUID,
                    UserName = "SYSTEM",
                    PasswordSalt = "12345678",
                    Password = hmac.ComputeHash(password),
                    ActiveStatus = true,
                    CreatedDateTime = DateTime.Now,
                    ModifiedDateTime = DateTime.Now,
                    CreatedById = defaultUID,
                    ModifiedById = defaultUID
                };
            }

            context.SysUserInfoes.Add(sysUser);

            SysConfig sysConfig = new SysConfig
            {
                ConfigurationID = new Guid("1D139358-A801-4653-A4A1-A6A333F16928"),
                ConfigurationName = "PasswordSalt",
                ConfigurationValue = "12345678"
            };
            context.SysConfigInfoes.Add(sysConfig);
            base.Seed(context);
            //HMACSHA512 hmac = new HMACSHA512(PasswordSalt);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.



        }
    }
}
