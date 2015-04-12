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
      private TextReader reader;

      public CsvProfileImporter(TextReader reader)
      {
          this.reader = reader;
      }

      public IList<Profile> Run()
      {
          IList<Profile> profiles = new List<Profile>();

          var csv = new CsvReader(reader);
          csv.Configuration.Delimiter = ",";
          

          while (csv.Read())
          {
              Profile profile = new Profile();
              //profile.CreatedAt = csv.GetField<string>(0);
              //profile.Gender = csv.GetField<string>(1);
              ProcessGender(profile, csv.GetField<string>(1), 1, csv.Row);
              //profile.EmploymentStatus = csv.GetField<string>(2);
              //profile.ReadingHabits = csv.GetField<string>(3).Split(',');
              //profile.BookGenres = csv.GetField<string>(4).Split(',');
              //profile.FilmGenres = csv.GetField<string>(5).Split(',');
              //profile.RelationshipStatus = csv.GetField<string>(6);
              //profile.HouseholdSize = csv.GetField<string>(7);
              //profile.Gadgets = csv.GetField<string>(8).Split(',');
              //profile.Children = csv.GetField<string>(10);
              //profile.HousingType = csv.GetField<string>(11);
              //profile.HouseholdControl = csv.GetField<string>(12);
              //profile.Salary = csv.GetField<string>(13);
              //profile.MajorPurchase = csv.GetField<string>(15);
              //profile.PurchaseDecision = csv.GetField<string>(16);
              //profile.BirthYear = csv.GetField<int>(17);

              profiles.Add(profile);
          }

          return profiles;
      }

      private void ProcessGender(Profile profile, string data, int fieldIndex, int rowIndex)
      {
          float value = 0f;

          if ("Male".Equals(data))
              value = 1;
          else if ("Female".Equals(data))
              value = 0;
          else
          {
              // TODO: Implement custom exception
              var msg = string.Format("Invalid value at line {0} field {1}", rowIndex, fieldIndex);
              throw new Exception(msg);
          }

          profile.AddValue("Gender", value);
      }
  }
}
