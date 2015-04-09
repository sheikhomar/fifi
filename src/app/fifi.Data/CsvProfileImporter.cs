using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using fifi.Core;


namespace fifi.Data
{
  public class CsvProfileImporter : IProfileImporter
  {
      void test()
      {
          List<Profile> userProfiles = new List<Profile>();

          var textReader = new StreamReader("UserData.csv");
          var csv = new CsvReader(textReader);
          csv.Configuration.Delimiter = ";";

          while (csv.Read())
          {
              Profile person = new Profile();
              person.CreatedAt = csv.GetField<string>(0);
              person.Gender = csv.GetField<string>(1);
              person.EmploymentStatus = csv.GetField<string>(2);
              person.ReadingHabits = csv.GetField<string>(3).Split(',');
              person.BookGenres = csv.GetField<string>(4).Split(',');
              person.FilmGenres = csv.GetField<string>(5).Split(',');
              person.RelationshipStatus = csv.GetField<string>(6);
              person.HouseholdSize = csv.GetField<string>(7);
              person.Gadgets = csv.GetField<string>(8).Split(',');
              person.Children = csv.GetField<string>(10);
              person.HousingType = csv.GetField<string>(11);
              person.HouseholdControl = csv.GetField<string>(12);
              person.Salary = csv.GetField<string>(13);
              person.MajorPurchase = csv.GetField<string>(15);
              person.PurchaseDecision = csv.GetField<string>(16);
              person.BirthYear = csv.GetField<int>(17);

              userProfiles.Add(person);
          }
      }
  }
}
