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

      public IdentifiableDataPointCollection Run()
      {
          IdentifiableDataPointCollection dataCollection = new IdentifiableDataPointCollection();
          //IList<Profile> profiles = new List<Profile>();

          var csv = new CsvReader(reader);
          csv.Configuration.Delimiter = ",";

          while (csv.Read())
          {
              var item = new DataItem();

              Gender(item, csv.GetField<string>(1), 1, csv.Row);
              EmploymentStatus(item, csv.GetField<string>(2), 2, csv.Row);

              //profile.ReadingHabits = csv.GetField<string>(3).Split(',');
              string[] readingHabits = csv.GetField<string>(3).Replace(", ", ",").Split(',');
              ReadingHabits(item, readingHabits, 2, csv.Row);

              //profile.BookGenres = csv.GetField<string>(4).Split(',');
              string[] bookGenres = csv.GetField<string>(4).Replace(", ", ",").Split(',');
              BookGenres(item, bookGenres, 2, csv.Row);

              //item.FilmGenres = csv.GetField<string>(5).Split(',');
              string[] filmGenres = csv.GetField<string>(5).Replace(", ", ",").Split(',');
              FilmGenres(item, filmGenres, 2, csv.Row);

              //item.RelationshipStatus = csv.GetField<string>(6);
              RelationshipStatus(item, csv.GetField<string>(6), 2, csv.Row);

              //item.HouseholdSize = csv.GetField<string>(7);
              HouseholdSize(item, csv.GetField<string>(7), 2, csv.Row);

              //item.Gadgets = csv.GetField<string>(8).Split(',');
              string[] gadgets = csv.GetField<string>(8).Replace(", ", ",").Split(',');
              Gadgets(item, gadgets, 2, csv.Row);

              //item.Children = csv.GetField<string>(10);
              Children(item, csv.GetField<string>(10), 2, csv.Row);

              //item.HousingType = csv.GetField<string>(11);
              HousingType(item, csv.GetField<string>(11), 2, csv.Row);

              //item.HouseholdControl = csv.GetField<string>(12);
              HouseholdControl(item, csv.GetField<string>(12), 2, csv.Row);

              //item.Salary = csv.GetField<string>(13);
              Salary(item, csv.GetField<string>(13), 2, csv.Row);

              //item.MajorPurchase = csv.GetField<string>(15);
              MajorPurchase(item, csv.GetField<string>(15), 2, csv.Row);

              //item.PurchaseDecision = csv.GetField<string>(16);
              PurchaseDecision(item, csv.GetField<string>(16), 2, csv.Row);

              //item.BirthYear = csv.GetField<double>(17);
              BirthYear(item, csv.GetField<double>(17), 2, csv.Row);

              dataCollection.AddItem(item);
          }

          return dataCollection;
      }

      private void Gender(DataItem item, string data, int fieldIndex, int rowIndex)
      {
          double value = 0D;

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

          item.AddValue(value);
      }

      private void EmploymentStatus(DataItem item, string data, int fieldIndex, int rowIndex)
      {
          if ("Full time".Equals(data))
              item.AddValue(1);
          else 
              item.AddValue(0);

          if ("Part time".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("Unemployed".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);
          
          if ("Studying".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("Study job".Equals(data) || "Studying with a study job".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("Retired".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);
      }

      private void ReadingHabits(DataItem item, string[] data, int fieldIndex, int rowIndex)
      {
            if (data.Contains("Books"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("Magazines"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("Newspapers"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("Specialist books"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("eBooks"))
                item.AddValue(1);
            else
                item.AddValue(0);
      }

      private void BookGenres(DataItem item, string[] data, int fieldIndex, int rowIndex) 
      {
            if (data.Contains("Novels"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("Thrillers"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("Comedies"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("Biographies"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("Comics"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("Scientific articles"))
                item.AddValue(1);
            else
                item.AddValue(0);
      }

      private void FilmGenres(DataItem item, string[] data, int fieldIndex, int rowIndex)
      {
            if (data.Contains("Crime and gangster"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("Comedies"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("Dramas"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("Sport"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("Thrillers"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("Documentaries"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("Romantic films"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("Art film"))
                item.AddValue(1);
            else
                item.AddValue(0);
      }

      private void RelationshipStatus(DataItem item, string data, int fieldIndex, int rowIndex)
      {
          if ("Single".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("Married".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("In a relationsship, but unmarried".Equals(data) || "In a relationsship".Equals(data) || "but unmarried".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("It's complicated".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("Divorced".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);
      }

      private void Gadgets(DataItem item, string[] data, int fieldIndex, int rowIndex)
      {
            if (data.Contains("A smartphone"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("A tablet"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("An MP3-player"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("A PC, Mac or laptop") || data.Contains("A PC or laptop") || data.Contains("A PC") || data.Contains("Mac or laptop"))
                item.AddValue(1);
            else
                item.AddValue(0);

            if (data.Contains("An eBook-reader"))
                item.AddValue(1);
            else
                item.AddValue(0);
      }

      private void HousingType(DataItem item, string data, int fieldIndex, int rowIndex)
      {
          if ("In a mansion or larger home".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("In a house".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("In an apartment".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("In a shared apartment".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("On a boat".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("Homeless".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);
      }

      private void HouseholdControl(DataItem item, string data, int fieldIndex, int rowIndex)
      {
          if ("Yes".Equals(data))
              item.AddValue(1);
          else if ("No".Equals(data))
              item.AddValue(0);
          else if ("Partially".Equals(data))
              item.AddValue(0.5);
      }

      private void HouseholdSize(DataItem item, string data, int fieldIndex, int rowIndex)
      {
          if ("I live alone".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("Two".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("Three".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("Four or more".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);
      }

      private void Children(DataItem item, string data, int fieldIndex, int rowIndex)
      {
          if ("None".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("One".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("Two".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("Three".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("Four or more".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);
      }

      private void Salary(DataItem item, string data, int fieldIndex, int rowIndex)
      {
          if ("Less than 750 €".Equals(data))
              item.AddValue(0.1429);
          else if ("750 -1000 €".Equals(data))
              item.AddValue(0.2858);
          else if ("1000 - 1500 €".Equals(data))
              item.AddValue(0.4287);
          else if ("1500 - 2000 €".Equals(data))
              item.AddValue(0.5716);
          else if ("2000 - 3000 €".Equals(data))
              item.AddValue(0.7145);
          else if ("3000 - 4000 €".Equals(data))
              item.AddValue(0.8574);
          else if ("More than 4000 €".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);
      }

      private void MajorPurchase(DataItem item, string data, int fieldIndex, int rowIndex)
      {
          if ("Let your emotions alone decide".Equals(data))
              item.AddValue(0);
          else if ("Let emotions decide more than rational thought".Equals(data))
              item.AddValue(0.25);
          else if ("Let rational thought decide more than emotions".Equals(data))
              item.AddValue(0.75);
          else if ("Let rational thought decide completely".Equals(data))
              item.AddValue(1);
          else if ("Both - 50/50".Equals(data))
              item.AddValue(0.50);
      }

      private void PurchaseDecision(DataItem item, string data, int fieldIndex, int rowIndex)
      {
          if ("The price".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("The brand".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("Test results and reviews".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("The store".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);

          if ("The envy of others".Equals(data))
              item.AddValue(1);
          else
              item.AddValue(0);
      }

      private void BirthYear(DataItem item, double data, int fieldIndex, int rowIndex)
      {
          double age;
          age = (DateTime.Now.Year - data) / 100;
          item.AddValue(age);
      }
  }
}
