using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace lab11_mvcApp.Models
{
    public class TimePerson
    {
        public int Year { get; set; }

        public string Honor { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public int Birth_Year { get; set; }

        public int DeathYear { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Context { get; set; }

        /// <summary>
        /// method to parse the persons from a year range
        /// </summary>
        /// <param name="begYear">starting year</param>
        /// <param name="endYear">ending year</param>
        /// <returns>list of persons</returns>
        // it is static so the class can apply this action
        public static List<TimePerson> GetPersons(int begYear, int endYear)
        {
            //instantiate a list with TimPerson objects
            List<TimePerson> people = new List<TimePerson>();
            //save the current directory path
            string path = Environment.CurrentDirectory;
            //saves the full path of the csv file by adding its path to the currenty directory 
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));
            //reads the file based on the full path for the csv
            string[] myFile = File.ReadAllLines(newPath);

            //loop to go through the csv of persons
            for (int i = 1; i < myFile.Length; i++)
            {
                //splits each field for each person
                string[] fields = myFile[i].Split(',');
                //instantiates a new object with all the properties values in the csv
                people.Add(new TimePerson
                {
                    Year = Convert.ToInt32(fields[0]),
                    Honor = fields[1],
                    Name = fields[2],
                    Country = fields[3],
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    Title = fields[6],
                    Category = fields[7],
                    Context = fields[8],
                });
            }
            //uses lambda expression to retrieve all the objects that are within the parameter years and saves them into a list
            List<TimePerson> listofPeople = people.Where(p => (p.Year >= begYear) && (p.Year <= endYear)).ToList();
            //returns the list of TimerPersons within the year range
            return listofPeople;

        }
    }
}
