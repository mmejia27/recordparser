using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordParser.API.Controllers;

namespace RecordParser.API.Test
{
    [TestClass]
    public class RecordsControllerTest
    {
        [TestMethod]
        public void Records_Get()
        {
            var controller = new RecordsController();
            controller.Post("Mike Adder Male Blue 01/01/2000");
            controller.Post("Jane Doe Female Green 03/03/1984");
            controller.Post("John Abb Male Black 05/05/1985");

            var result = controller.Get();
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod]
        public void Records_GetByGender()
        {
            var controller = new RecordsController();

            var result = controller.GetByGender();
            Assert.AreEqual(result.First().Gender, "Female");
        }

        [TestMethod]
        public void Records_GetByBirthdate()
        {
            var controller = new RecordsController();

            var result = controller.GetByBirthdate();
            Assert.AreEqual(result.First().LastName, "Doe");
        }

        [TestMethod]
        public void Records_GetByName()
        {
            var controller = new RecordsController();

            var result = controller.GetByName();
            Assert.AreEqual(result.Count(), 3);
            Assert.AreEqual(result.First().LastName, "Abb");
        }
    }
}
