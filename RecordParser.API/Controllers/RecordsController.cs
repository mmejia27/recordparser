using RecordParser.API.Models;
using RecordParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecordParser.API.Controllers
{
    public class RecordsController : ApiController
    {
        // GET: api/records
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return PersonData.Instance.Persons;
        }

        // GET: api/records/gender
        [Route("api/records/gender")]
        public IEnumerable<Person> GetByGender()
        {
            return PersonData.Instance.Persons.OrderBy(p => p.Gender);
        }

        // GET: api/records/birthdate
        [Route("api/records/birthdate")]
        public IEnumerable<Person> GetByBirthdate()
        {
            return PersonData.Instance.Persons.OrderBy(p => p.DateOfBirth);
        }

        // GET: api/records/name
        [Route("api/records/name")]
        public IEnumerable<Person> GetByName()
        {
            return PersonData.Instance.Persons.OrderBy(p => p.LastName);
        }

        // POST: api/records
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var person = Person.ParseRecord(value);

            PersonData.Instance.Persons.Add(person);

        }
    }
}
