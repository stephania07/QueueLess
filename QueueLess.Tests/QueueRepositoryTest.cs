using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueueLess.Repository;
using QueueLess.Models;
using System.Collections.Generic;

namespace QueueLess.Tests
{
    [TestClass]
    public class QueueRepositoryTest
    {
        private static QueueRepository repo;
        
        [ClassInitialize]
        public static void SetUp(TestContext _context)
        {
            repo = new QueueRepository("Name = QueueTest");
            repo.Clear();
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            repo.Clear();        
        }

        [TestCleanup]
        public void ClearDatabase()
        {
            repo.Clear();
        }
        //All 4 Tests To be revised
        [TestMethod]
        public void TestAddToDatabase()
        {
            Assert.AreEqual(4, repo.GetCount());
            repo.Add(new Queue("Existing", "John", "Robert", "1234567899", "J@gmail.com", "08:00 AM", "08:30 AM", 30, 2));
            Assert.AreEqual(1, repo.GetCount());
        }

        [TestMethod]
        public void TestGetCount()
        {
            Assert.AreEqual(0, repo.GetCount());
            repo.Add(new Queue("New", "Andrew", "Rora", "2345678991", "A@gmail.com", "09:00 AM", "10:30 AM", 90, 5));
            Assert.AreEqual(1, repo.GetCount());
        }

        [TestMethod]
        public void TestClear()
        {
            repo.Add(new Queue("New", "Ann", "Robert", "3456789912", "An@gmail.com", "10:00 AM", "11:30 AM", 90, 4));
            repo.Clear();
            Assert.AreEqual(1, repo.GetCount());
        }

        [TestMethod]
        public void TestAllMethod()
        {
            repo.Add(new Queue("New", "Ann", "Robert", "3456789912", "An@gmail.com", "10:00 AM", "11:30 AM", 90, 4));
            repo.Add(new Queue("New", "Andrew", "Rora", "2345678991", "A@gmail.com", "09:00 AM", "10:30 AM", 90, 5));
            repo.Add(new Queue("Existing", "John", "Robert", "1234567899", "J@gmail.com", "08:00 AM", "08:30 AM", 30, 2));
            repo.Add(new Queue("Existing", "Franklin","John", "5678991234","Fj@gmail.com","12:00 AM","12:45 AM", 45, 4 ));

            Assert.AreEqual(4, repo.GetCount());
        }

        [TestMethod]
        public void TestDelete()
        {
            //List<Queue> customers = repo.All();
            //Assert.AreEqual(2, customers.Count);
            //var firstCustomerId = customers[0].ID;
            //repo.Delete(firstCustomerId);
            //List<Queue> newCustomersList = repo.All();
            //Assert.AreEqual(1, repo.GetCount());

        }
                
    }
}
