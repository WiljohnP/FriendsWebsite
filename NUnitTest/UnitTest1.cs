using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebApplication1.Controller;

namespace NUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_hashPlaintext()
        {
            //ARRANGE
            UserControl uc = new UserControl();

            //ACT
            string result = uc.hashPlaintext("manager"); //SHA-512

            //ASSERT
            Assert.AreEqual("5fc2ca6f085919f2f77626f1e280fab9cc92b4edc9edc53ac6eee3f72c5c508e869ee9d67a96d63986d14c1c2b82c35ff5f31494bea831015424f59c96fff664", result);

        }

        //[TestMethod]
        //public void Test_isUserExists()
        //{
        //    //ARRANGE
        //    UserControl uc = new UserControl();

        //    //ACT
        //    bool result = uc.isUserExists("manager");

        //    //ASSERT
        //    Assert.AreEqual(true, result);
        //}

        //[TestMethod]
        //public void Test_validatePassword()
        //{
        //    //ARRANGE
        //    UserControl uc = new UserControl();

        //    //ACT
        //    string result = uc.validatePassword("staff","not-staff-password");

        //    //ASSERT
        //    Assert.AreEqual("wrong password", result);

        //}
    }
}
