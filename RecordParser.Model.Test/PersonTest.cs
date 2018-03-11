using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecordParser.Model.Test
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParseRecord_NotNull()
        {
            Person.ParseRecord(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseRecord_InvalidSeparator()
        {
            Person.ParseRecord("John[Doe[Male[Teal[03/03/1986");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseRecord_InvalidNumberOfFields()
        {
            Person.ParseRecord("John | Alexander | Doe | Male | Teal | 03/03/1986");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseRecord_InvalidDate()
        {
            Person.ParseRecord("John | Doe | Male | Teal | 50/60/1986");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseRecord_MissingField()
        {
            Person.ParseRecord("John | Male | Teal | 50/60/1986");
        }

        [TestMethod]
        public void ParseRecord_ValidRecordPipe()
        {
            var person = Person.ParseRecord("John | Doe | Male | Teal | 03/03/1986");
            Assert.AreEqual(person.FirstName, "John");
            Assert.AreEqual(person.LastName, "Doe");
            Assert.AreEqual(person.Gender, "Male");
            Assert.AreEqual(person.FavoriteColor, "Teal");
            Assert.AreEqual(person.DateOfBirth, DateTime.Parse("03/03/1986"));
        }

        [TestMethod]
        public void ParseRecord_ValidRecordComma()
        {
            var person = Person.ParseRecord("John, Doe, Male, Teal, 03/03/1986");
            Assert.AreEqual(person.FirstName, "John");
            Assert.AreEqual(person.LastName, "Doe");
            Assert.AreEqual(person.Gender, "Male");
            Assert.AreEqual(person.FavoriteColor, "Teal");
            Assert.AreEqual(person.DateOfBirth, DateTime.Parse("03/03/1986"));
        }

        [TestMethod]
        public void ParseRecord_ValidRecordSpace()
        {
            var person = Person.ParseRecord("John Doe Male Teal 03/03/1986");
            Assert.AreEqual(person.FirstName, "John");
            Assert.AreEqual(person.LastName, "Doe");
            Assert.AreEqual(person.Gender, "Male");
            Assert.AreEqual(person.FavoriteColor, "Teal");
            Assert.AreEqual(person.DateOfBirth, DateTime.Parse("03/03/1986"));
        }
    }
}
