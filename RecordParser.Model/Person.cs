using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordParser.Model
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string FavoriteColor { get; set; }
        public DateTime DateOfBirth { get; set; }

        public static Person ParseRecord(string record)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(record)) throw new ArgumentNullException("record", "Record must not be null or empty");

            char separator;
            if (record.Contains("|")) separator = '|';
            else if (record.Contains(",")) separator = ',';
            else if (record.Contains(" ")) separator = ' ';
            else throw new ArgumentException("Fields are not delimited by either '|', ',', or ' ' (space).", "record");

            var fields = record.Split(separator);
            if (fields.Length != 5) throw new ArgumentException("Each record must contain exactly 5 fields", "record");

            DateTime dob;
            if (!DateTime.TryParse(fields[4], out dob)) throw new ArgumentException("The date of birth field (5) must be a valid date", "record");

            var person = new Person()
            {
                FirstName = fields[0].Trim(),
                LastName = fields[1].Trim(),
                Gender = fields[2].Trim(),
                FavoriteColor = fields[3].Trim(),
                DateOfBirth = dob
            };

            return person;
        }
    }
}
