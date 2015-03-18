using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueueLess.Models;

namespace QueueLess.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestQueueProperties()
        {
            Queue customer = new Queue("New", "Ann", "Robert", "3456789912", "An@gmail.com", "10:00 AM", "11:30 AM", 90, 4);
            Assert.AreEqual("New", customer.Service);
            Assert.AreEqual("Ann", customer.FirstName);
            Assert.AreEqual("Robert", customer.LastName);
            Assert.AreEqual("3456789912", customer.PhoneNumber);
            Assert.AreEqual("An@gmail.com", customer.Email);
            Assert.AreEqual("10:00 AM", customer.RegistrationTime );
            Assert.AreEqual("11:30 AM", customer.CurrentTime);
            Assert.AreEqual(90, customer.EstimatedMinutes );
            Assert.AreEqual(4, customer.PeopleOnQueue);
        }
    }
}
