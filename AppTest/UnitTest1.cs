using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App;

namespace AppTest
{
    [TestClass]
    public class ValidNameTest
    {
        [TestMethod]
        public void valid_name_return_true()
        {
            var result = CustomerService.IsNameValid("richard", "hamilton");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void invalid_name_return_false()
        {
            var result = CustomerService.IsNameValid(null, "hamilton");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void invalid_name2_return_false()
        {
            var result = CustomerService.IsNameValid("james", "");
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class ValidEmailTest
    {
        [TestMethod]
        public void valid_name_return_true()
        {
            var result = CustomerService.IsEmailValid("ricky@bob.com");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void invalid_name_return_false()
        {
            var result = CustomerService.IsEmailValid("ricky@something");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void invalid_name2_return_false()
        {
            var result = CustomerService.IsEmailValid("ricky.com");
            Assert.IsFalse(result);
        }
    }
}

    //didn't have time to complete this one as I need the test and age to return true now or in 5 years time so the result will change
    //[TestClass]
    //public class GetAgeTest
    