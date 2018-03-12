using RecordParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordParser.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("You must pass at least one file to parse");
            }

            try
            {
                List<Person> persons = new List<Person>();
                foreach (var file in args)
                {
                    if (!File.Exists(file))
                    {
                        Console.WriteLine("{0} does not exist. Skipping...", file);
                        continue;
                    }

                    foreach (var line in File.ReadLines(file))
                    {
                        try
                        {
                            var person = Person.ParseRecord(line);
                            persons.Add(person);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("Invalid record in {0}. Message: {1} Data: {2}", file, ex.Message, line);
                            continue;
                        }
                    }
                }

                Console.WriteLine($"Found {persons.Count} person(s)\n");
                
                var personsByGender = persons.OrderBy(p => p.Gender).ThenBy(p => p.LastName);
                DisplayData(personsByGender, "Sorted by gender, then last name");

                var personsByDate = persons.OrderBy(p => p.DateOfBirth);
                DisplayData(personsByDate, "Sorted by date of birth");
                
                var personsByLast = persons.OrderByDescending(p => p.LastName);
                DisplayData(personsByLast, "Sorted by last name, descending");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong.\n {0}", ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
        
        static void DisplayData(IEnumerable<Person> persons, string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("================================================================");
            foreach (var person in persons)
            {
                Console.Write($"{person.FirstName,-10} {person.LastName,-10} {person.Gender,-8}");
                Console.Write($"{person.FavoriteColor,-10} {person.DateOfBirth.ToString("M/d/yyyy"),10}\n");
            }
            Console.WriteLine("================================================================");
        }
    }
}
