using App.Core.Data.AuthDBContext;
using App.Core.SysInfo;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
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

                if (sysUser.Password.SequenceEqual(generatePassword(userLogIn.Password, sysUser.PasswordSalt)))
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

            return sysUserLogInResponse;
        }

        public SysCreateUserLogInResponse AddSysUser(SysUserLogIn userLogIn)
        {
            SysCreateUserLogInResponse sysUserLogInResponse;// = new 
                //SysCreateUserLogInResponse();
            using (AuthDBCon dbc = new AuthDBCon())
            {
                SysConfig sysConfig = dbc.SysConfigInfoes.Where(x => x.ConfigurationName == "PasswordSalt").FirstOrDefault();

                if (sysConfig == null)
                {
                    sysUserLogInResponse = new SysCreateUserLogInResponse
                    {
                        StatusCode = "01",
                        StatusDescription = "Configuration Issue"
                    };

                    return sysUserLogInResponse;
                }

                SysUser sysUser = new SysUser
                {
                    UserId = Guid.NewGuid(),
                    UserName = userLogIn.UserName,
                    CreatedById = userLogIn.CreatedBy,
                    ModifiedById = userLogIn.CreatedBy,
                    CreatedDateTime = DateTime.Now,
                    ModifiedDateTime = DateTime.Now,
                    PasswordSalt = sysConfig.ConfigurationValue,
                    Password = generatePassword(userLogIn.Password, sysConfig.ConfigurationValue),
                    ActiveStatus = true
                    

                };

                try
                {
                    dbc.Set<SysUser>();
                    dbc.SysUserInfoes.Add(sysUser);
                    dbc.SaveChanges();
                    sysUserLogInResponse = new SysCreateUserLogInResponse
                    {
                        StatusCode = "00",
                        StatusDescription = "",
                        UserId = sysUser.UserId,
                        UserName = sysUser.UserName

                    };

                }
                catch (DbUpdateException dbUpdateEx)
                {
                    string code = "";
                    string message = "";
                    if (dbUpdateEx.InnerException.InnerException is SqlException sqlException)
                    {
                        switch (sqlException.Number)
                        {
                            case 2601:
                                code = "02";
                                message = "Invalid Username";
                                break;
                            default:
                                code = "02";
                                message = dbUpdateEx.Message;
                                break;
                        }
                    }
                    else
                    {
                        code = "02";
                        message = dbUpdateEx.Message;
                    }

                        sysUserLogInResponse = new SysCreateUserLogInResponse
                    {
                        StatusCode = code,
                        StatusDescription = message
                    };
                }
                catch (Exception ex)
                {
                    sysUserLogInResponse = new SysCreateUserLogInResponse
                    {
                        StatusCode = "01",
                        StatusDescription = ex.InnerException.ToString()
                    };
                }

                return sysUserLogInResponse;

                

            }

            
            


            //using (AuthDBCon dbc = new AuthDBCon()) { }


               // return sysUserLogInResponse;
        }

        //public virtual SysCreateUserLogInResponse HandleException(Exception exception)
        //{

        //}

        private byte[] generatePassword(string password, string passwordSalt)
        {
            Byte[] pswSalt = Encoding.ASCII.GetBytes(passwordSalt);
            byte[] pswd = Encoding.ASCII.GetBytes(password);

            using (HMACSHA512 hmac = new HMACSHA512(pswSalt))
            {
                return hmac.ComputeHash(pswd);
            }
        }


    }
}
