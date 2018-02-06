using App.Core.Data.AuthDBContext;
using App.Core.SysInfo;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace App.Core.Data.SysData
{
    public class SysUserData
    {
        public SysUserLogInResponse ValidateSysUser(SysUserLogIn userLogIn)
        {
            SysUser sysUser;
            SysUserLogInResponse sysUserLogInResponse;
            using (AuthDBCon dbc = new AuthDBCon())
            {
                sysUser=dbc.SysUserInfoes.Where(x => x.UserName == userLogIn.UserName).FirstOrDefault();
            }

            if (sysUser == null)
            {
                sysUserLogInResponse = new SysUserLogInResponse
                {
                    StatusCode = "01",
                    StatusDescription = "Invalid"
                };
            }
            else
            {
                Byte[] PasswordSalt = Encoding.ASCII.GetBytes(sysUser.PasswordSalt);
                byte[] password = Encoding.ASCII.GetBytes(userLogIn.Password);
                
                using (HMACSHA512 hmac = new HMACSHA512(PasswordSalt))
                {

                    if (sysUser.Password.SequenceEqual(hmac.ComputeHash(password)))
                    {
                        sysUserLogInResponse = new SysUserLogInResponse
                        {
                            StatusCode = "00",
                            StatusDescription = "Valid",
                            UserId = sysUser.UserId,
                            UserName = sysUser.UserName


                        };
                    }
                    else
                    {
                        sysUserLogInResponse = new SysUserLogInResponse
                        {
                            StatusCode = "01",
                            StatusDescription = "Invalid"
                        };
                    }
                    
                }
            }

            return sysUserLogInResponse;
        }
    }
}
