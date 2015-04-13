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

              //profile.BirthYear = csv.GetField<double>(17);

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
              profile.AddValue("Household Control", 1);
          else if ("No".Equals(data))
              profile.AddValue("Household Control", 0);
          else if ("Partially".Equals(data))
              profile.AddValue("Household Control", 1/2);
      }

      private void ProcessHouseholdSize(Profile profile, string data, int fieldIndex, int rowIndex)
      {
          if ("I live alone".Equals(data))
              profile.AddValue("I live alone", 1);
          else
              profile.AddValue("I live alone", 0);

          if ("Two".Equals(data))
              profile.AddValue("Two", 1);
          else
              profile.AddValue("Two", 0);

          if ("Three".Equals(data))
              profile.AddValue("Three", 1);
          else
              profile.AddValue("Three", 0);

          if ("Four or more".Equals(data))
              profile.AddValue("Four or more", 1);
          else
              profile.AddValue("Four or more", 0);
      }

      private void ProcessChildren(Profile profile, string data, int fieldIndex, int rowIndex)
      {
          if ("None".Equals(data))
              profile.AddValue("None", 1);
          else
              profile.AddValue("None", 0);

          if ("One".Equals(data))
              profile.AddValue("One", 1);
          else
              profile.AddValue("One", 0);

          if ("Two".Equals(data))
              profile.AddValue("Two", 1);
          else
              profile.AddValue("Two", 0);

          if ("Three".Equals(data))
              profile.AddValue("Three", 1);
          else
              profile.AddValue("Three", 0);

          if ("Four or more".Equals(data))
              profile.AddValue("Four or more", 1);
          else
              profile.AddValue("Four or more", 0);
      }

      private void ProcessSalary(Profile profile, string data, int fieldIndex, int rowIndex)
      {
          if ("Less than 750 €".Equals(data))
              profile.AddValue("Salary", 1/7);
          else if ("750 -1000 €".Equals(data))
              profile.AddValue("Salary", 2/7);
          else if ("1000 - 1500 €".Equals(data))
              profile.AddValue("Salary", 3/7);
          else if ("1500 - 2000 €".Equals(data))
              profile.AddValue("Salary", 4/7);
          else if ("2000 - 3000 €".Equals(data))
              profile.AddValue("Salary", 5/7);
          else if ("3000 - 4000 €".Equals(data))
              profile.AddValue("Salary", 6/7);
          else if ("More than 4000 €".Equals(data))
              profile.AddValue("Salary", 1);
      }

      private void ProcessMajorPurchase(Profile profile, string data, int fieldIndex, int rowIndex)
      {
          if ("Let your emotions alone decide".Equals(data))
              profile.AddValue("Major Purchase", 0);
          else if ("Let emotions decide more than rational thought".Equals(data))
              profile.AddValue("Major Purchase", 1/4);
          else if ("Let rational thought decide more than emotions".Equals(data))
              profile.AddValue("Major Purchase", 3/4);
          else if ("Let rational thought decide completely".Equals(data))
              profile.AddValue("Major Purchase", 1);
          else if ("Both - 50/50".Equals(data))
              profile.AddValue("Major Purchase", 2/4);
      }

      private void ProcessPurchaseDecision(Profile profile, string data, int fieldIndex, int rowIndex)
      {
          if ("The price".Equals(data))
              profile.AddValue("The price", 1);
          else
              profile.AddValue("The price", 0);

          if ("The brand".Equals(data))
              profile.AddValue("The brand", 1);
          else
              profile.AddValue("The brand", 0);

          if ("Test results and reviews".Equals(data))
              profile.AddValue("Test results and reviews", 1);
          else
              profile.AddValue("Test results and reviews", 0);

          if ("The store".Equals(data))
              profile.AddValue("The store", 1);
          else
              profile.AddValue("The store", 0);

          if ("The envy of others".Equals(data))
              profile.AddValue("The envy of others", 1);
          else
              profile.AddValue("The envy of others", 0);
      }

      private void ProcessBirthYear(Profile profile, double data, int fieldIndex, int rowIndex)
      {
          double age;
          age = (DateTime.Now.Year - data) / 100;
          profile.AddValue("Age", age);
      }
  }
}
