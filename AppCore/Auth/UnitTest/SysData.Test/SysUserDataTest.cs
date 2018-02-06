using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Core.Data.SysData;
using App.Core.SysInfo;

namespace SysData.Test
{
    [TestClass]
    public class SysUserDataTest
    {
        [TestMethod]
        public void ValidLogIn()
        {
            SysUserData sysUserData = new SysUserData();
            SysUserLogIn userLogIn = new SysUserLogIn
            {
                UserName = "SYSTEM",
                Password = "12345678"
            };
            SysUserLogInResponse sysUserLogInResponse=
            sysUserData.ValidateSysUser(userLogIn);

            Assert.AreEqual("00", sysUserLogInResponse.StatusCode);
        }

        [TestMethod]
        public void InvalidUserName()
        {
            SysUserData sysUserData = new SysUserData();
            SysUserLogIn userLogIn = new SysUserLogIn
            {
                UserName = "Invalid",
                Password = "12345678"
            };
            SysUserLogInResponse sysUserLogInResponse =
            sysUserData.ValidateSysUser(userLogIn);

            Assert.AreEqual("01", sysUserLogInResponse.StatusCode);
        }

        [TestMethod]
        public void InvalidPassword()
        {
            SysUserData sysUserData = new SysUserData();
            SysUserLogIn userLogIn = new SysUserLogIn
            {
                UserName = "SYSTEM",
                Password = "22222"
            };
            SysUserLogInResponse sysUserLogInResponse =
            sysUserData.ValidateSysUser(userLogIn);

            Assert.AreEqual("01", sysUserLogInResponse.StatusCode);
        }

        [TestMethod]
        public void AddNewUser()
        {
            SysUserData sysUserData = new SysUserData();
            SysUserLogIn userLogIn = new SysUserLogIn
            {
                UserName = "test1",
                Password = "123456",
                CreatedBy= new Guid("DAD2C21E-CD39-46FE-A1E3-C61CD3B66362")
            };
            SysCreateUserLogInResponse sysUserLogInResponse = sysUserData.AddSysUser(userLogIn);

            Assert.AreEqual("00", sysUserLogInResponse.StatusCode);

        }

        [TestMethod]
        public void AddDuplicateUser()
        {
            SysUserData sysUserData = new SysUserData();
            SysUserLogIn userLogIn = new SysUserLogIn
            {
                UserName = "SYSTEM",
                Password = "22222",
                CreatedBy = new Guid("DAD2C21E-CD39-46FE-A1E3-C61CD3B66362")
            };
            SysCreateUserLogInResponse sysUserLogInResponse = sysUserData.AddSysUser(userLogIn);

            Assert.AreEqual("02", sysUserLogInResponse.StatusCode);

        }
    }
}
