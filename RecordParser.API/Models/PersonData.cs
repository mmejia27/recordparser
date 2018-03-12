using RecordParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordParser.API.Models
{
    public sealed class PersonData
    {
        private static readonly PersonData instance = new PersonData();

        private PersonData() { }

        public static PersonData Instance
        {
            get
            {
                return instance;
            }
        }

        public List<Person> Persons { get; set; } = new List<Person>();
    }
}