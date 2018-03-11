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
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("Invalid record in {0}. Message: {1} Data: {2}", file, ex.Message, line);
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong.\n {0}", ex.Message);
            }
        }
    }
}
