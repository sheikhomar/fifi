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
              ProcessEmploymentStatus(profile, csv.GetField<string>(2), 2, csv.Row);
              //profile.ReadingHabits = csv.GetField<string>(3).Split(',');
              string[] ReadingHabits = csv.GetField<string>(3).Split(',');
              ProcessReadingHabits(profile, ReadingHabits, 2, csv.Row);
              //profile.BookGenres = csv.GetField<string>(4).Split(',');
              string[] BookGenres = csv.GetField<string>(4).Split(',');
              ProcessBookGenres(profile, BookGenres, 2, csv.Row);
              //profile.FilmGenres = csv.GetField<string>(5).Split(',');
              string[] FilmGenres = csv.GetField<string>(5).Split(',');
              ProcessFilmGenres(profile, FilmGenres, 2, csv.Row);
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

      private void ProcessEmploymentStatus(Profile profile, string data, int fieldIndex, int rowIndex)
      {
          if ("Full time".Equals(data))
              profile.AddValue("Full time", 1);
          else 
               profile.AddValue("Full time", 0);

          if ("Part time".Equals(data))
              profile.AddValue("Part time", 1);
          else
              profile.AddValue("Part time", 0);

          if ("Unemployed".Equals(data))
              profile.AddValue("Unemployed", 1);
          else
              profile.AddValue("Unemployed", 0);
          
          if ("Studying".Equals(data))
              profile.AddValue("Studying", 1);
          else
              profile.AddValue("Studying", 0);

          if ("Studying with a study job".Equals(data))
              profile.AddValue("Studying with a study job", 1);
          else
              profile.AddValue("Studying with a study job", 0);

          if ("Retired".Equals(data))
              profile.AddValue("Retired", 1);
          else
              profile.AddValue("Retired", 0);
      }

      private void ProcessReadingHabits(Profile profile, string[] data, int fieldIndex, int rowIndex)
      {
          for (int i = 0; i < data.Length; i++)
          {
              if ("Books".Equals(data))
                  profile.AddValue("Books", 1);
              else
                  profile.AddValue("Books", 0);

              if ("Magazines".Equals(data))
                  profile.AddValue("Magazines", 1);
              else
                  profile.AddValue("Magazines", 0);

              if ("Newspapers".Equals(data))
                  profile.AddValue("Newspapers", 1);
              else
                  profile.AddValue("Newspapers", 0);

              if ("Specialist books".Equals(data))
                  profile.AddValue("Specialist books", 1);
              else
                  profile.AddValue("Specialist books", 0);

              if ("eBooks".Equals(data))
                  profile.AddValue("eBooks", 1);
              else
                  profile.AddValue("eBooks", 0);
          }
      }

      private void ProcessBookGenres(Profile profile, string[] data, int fieldIndex, int rowIndex) 
      {
          for (int i = 0; i < data.Length; i++)
          {
              if ("Novels".Equals(data))
                  profile.AddValue("Novels", 1);
              else 
                  profile.AddValue("Novels", 0);

              if ("Thrillers".Equals(data))
                  profile.AddValue("Thrillers", 1);
              else
                  profile.AddValue("Thrillers", 0);

              if ("Comedies".Equals(data))
                  profile.AddValue("Comedies", 1);
              else
                  profile.AddValue("Comedies", 0);

              if ("Biographies".Equals(data))
                  profile.AddValue("Biographies", 1);
              else
                  profile.AddValue("Biographies", 0);

              if ("Comics".Equals(data))
                  profile.AddValue("Comics", 1);
              else
                  profile.AddValue("Comics", 0);

              if ("Scientific articles".Equals(data))
                  profile.AddValue("Scientific articles", 1);
              else
                  profile.AddValue("Scientific articles", 0);
          }
      }

      private void ProcessFilmGenres(Profile profile, string[] data, int fieldIndex, int rowIndex)
      {
          for (int i = 0; i < data.Length; i++)
          {
              if ("Crime and gangster".Equals(data))
                  profile.AddValue("Crime and gangster", 1);
              else
                  profile.AddValue("Crime and gangster", 0);

              if ("Comedies".Equals(data))
                  profile.AddValue("Comedies", 1);
              else
                  profile.AddValue("Comedies", 0);

              if ("Dramas".Equals(data))
                  profile.AddValue("Dramas", 1);
              else
                  profile.AddValue("Dramas", 0);

              if ("Sport".Equals(data))
                  profile.AddValue("Sport", 1);
              else
                  profile.AddValue("Sport", 0);

              if ("Thrillers".Equals(data))
                  profile.AddValue("Thrillers", 1);
              else
                  profile.AddValue("Thrillers", 0);

              if ("Documentaries".Equals(data))
                  profile.AddValue("Documentaries", 1);
              else
                  profile.AddValue("Documentaries", 0);

              if ("Romantic films".Equals(data))
                  profile.AddValue("Romantic films", 1);
              else
                  profile.AddValue("Romantic films", 0);

              if ("Art film".Equals(data))
                  profile.AddValue("Art film", 1);
              else
                  profile.AddValue("Art film", 0);
          }
      }

      private void ProcessGadgets(Profile profile, string[] data, int fieldIndex, int rowIndex)
      {
          for (int i = 0; i < data.Length; i++)
          {
              if ("A smartphone".Equals(data))
                  profile.AddValue("A smartphone", 1);
              else
                  profile.AddValue("A smartphone", 0);

              if ("A tablet".Equals(data))
                  profile.AddValue("A tablet", 1);
              else
                  profile.AddValue("A tablet", 0);

              if ("An MP3-player".Equals(data))
                  profile.AddValue("An MP3-player", 1);
              else
                  profile.AddValue("An MP3-player", 0);

              if ("A PC, Mac or laptop".Equals(data))
                  profile.AddValue("A PC, Mac or laptop", 1);
              else
                  profile.AddValue("A PC, Mac or laptop", 0);

              if ("An eBook-reader".Equals(data))
                  profile.AddValue("An eBook-reader", 1);
              else
                  profile.AddValue("An eBook-reader", 0);
          }
      }

      private void ProcessHousingType(Profile profile, string data, int fieldIndex, int rowIndex)
      {
          if ("In a mansion or larger home".Equals(data))
              profile.AddValue("In a mansion or larger home", 1);
          else
              profile.AddValue("In a mansion or larger home", 0);

          if ("In a house".Equals(data))
              profile.AddValue("In a house", 1);
          else
              profile.AddValue("In a house", 0);

          if ("In an apartment".Equals(data))
              profile.AddValue("In an apartment", 1);
          else
              profile.AddValue("In an apartment", 0);

          if ("In a shared apartment".Equals(data))
              profile.AddValue("In a shared apartment", 1);
          else
              profile.AddValue("In a shared apartment", 0);

          if ("On a boat".Equals(data))
              profile.AddValue("On a boat", 1);
          else
              profile.AddValue("On a boat", 0);

          if ("Homeless".Equals(data))
              profile.AddValue("Homeless", 1);
          else
              profile.AddValue("Homeless", 0);
      }

      private void ProcessHouseholdControl(Profile profile, string data, int fieldIndex, int rowIndex)
      {
          if ("Yes".Equals(data))
              profile.AddValue("Yes", 1);
          else
              profile.AddValue("Yes", 0);

          if ("No".Equals(data))
              profile.AddValue("No", 1);
          else
              profile.AddValue("No", 0);

          if ("Partially".Equals(data))
              profile.AddValue("Partially", 1);
          else
              profile.AddValue("Partially", 0);
      }
  }
}
