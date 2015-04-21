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
    public class CsvDataImporter : IProfileImporter
    {
        private TextReader reader;

        public CsvDataImporter(TextReader reader)
        {
            this.reader = reader;
        }

        public IdentifiableDataPointCollection Run()
        {
            var dataSet = new IdentifiableDataPointCollection();

            var csv = new CsvReader(reader);
            csv.Configuration.Delimiter = ",";

            var idCounter = 0;
            while (csv.Read())
            {
                IdentifiableDataPoint profile = new IdentifiableDataPoint(idCounter++, 60);
                ProcessGender(profile, csv.GetField<string>(1), 1, csv.Row);

                //profile.EmploymentStatus = csv.GetField<string>(2);
                ProcessEmploymentStatus(profile, csv.GetField<string>(2), 2, csv.Row);

                //profile.ReadingHabits = csv.GetField<string>(3).Split(',');
                string[] ReadingHabits = csv.GetField<string>(3).Replace(", ", ",").Split(',');
                ProcessReadingHabits(profile, ReadingHabits, 2, csv.Row);

                //profile.BookGenres = csv.GetField<string>(4).Split(',');
                string[] BookGenres = csv.GetField<string>(4).Replace(", ", ",").Split(',');
                ProcessBookGenres(profile, BookGenres, 2, csv.Row);

                //profile.FilmGenres = csv.GetField<string>(5).Split(',');
                string[] FilmGenres = csv.GetField<string>(5).Replace(", ", ",").Split(',');
                ProcessFilmGenres(profile, FilmGenres, 2, csv.Row);

                //profile.RelationshipStatus = csv.GetField<string>(6);
                ProcessRelationshipStatus(profile, csv.GetField<string>(6), 2, csv.Row);

                //profile.HouseholdSize = csv.GetField<string>(7);
                ProcessHouseholdSize(profile, csv.GetField<string>(7), 2, csv.Row);

                //profile.Gadgets = csv.GetField<string>(8).Split(',');
                string[] Gadgets = csv.GetField<string>(8).Replace(", ", ",").Split(',');
                ProcessGadgets(profile, Gadgets, 2, csv.Row);

                //profile.Children = csv.GetField<string>(10);
                ProcessChildren(profile, csv.GetField<string>(10), 2, csv.Row);

                //profile.HousingType = csv.GetField<string>(11);
                ProcessHousingType(profile, csv.GetField<string>(11), 2, csv.Row);

                //profile.HouseholdControl = csv.GetField<string>(12);
                ProcessHouseholdControl(profile, csv.GetField<string>(12), 2, csv.Row);

                //profile.Salary = csv.GetField<string>(13);
                ProcessSalary(profile, csv.GetField<string>(13), 2, csv.Row);

                //profile.MajorPurchase = csv.GetField<string>(15);
                ProcessMajorPurchase(profile, csv.GetField<string>(15), 2, csv.Row);

                //profile.PurchaseDecision = csv.GetField<string>(16);
                ProcessPurchaseDecision(profile, csv.GetField<string>(16), 2, csv.Row);

                //profile.BirthYear = csv.GetField<double>(17);
                ProcessBirthYear(profile, csv.GetField<double>(17), 2, csv.Row);

                dataSet.AddItem(profile);
            }

            return dataSet;
        }

        private void ProcessGender(IdentifiableDataPoint profile, string data, int fieldIndex, int rowIndex)
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

            profile.AddAttribute("Gender", value);
        }

        private void ProcessEmploymentStatus(IdentifiableDataPoint profile, string data, int fieldIndex, int rowIndex)
        {
            if ("Full time".Equals(data))
                profile.AddAttribute("Full time", 1);
            else
                profile.AddAttribute("Full time", 0);

            if ("Part time".Equals(data))
                profile.AddAttribute("Part time", 1);
            else
                profile.AddAttribute("Part time", 0);

            if ("Unemployed".Equals(data))
                profile.AddAttribute("Unemployed", 1);
            else
                profile.AddAttribute("Unemployed", 0);

            if ("Studying".Equals(data))
                profile.AddAttribute("Studying", 1);
            else
                profile.AddAttribute("Studying", 0);

            if ("Study job".Equals(data) || "Studying with a study job".Equals(data))
                profile.AddAttribute("Study job", 1);
            else
                profile.AddAttribute("Study job", 0);

            if ("Retired".Equals(data))
                profile.AddAttribute("Retired", 1);
            else
                profile.AddAttribute("Retired", 0);
        }

        private void ProcessReadingHabits(IdentifiableDataPoint profile, string[] data, int fieldIndex, int rowIndex)
        {
            if (data.Contains("Books"))
                profile.AddAttribute("Books", 1);
            else
                profile.AddAttribute("Books", 0);

            if (data.Contains("Magazines"))
                profile.AddAttribute("Magazines", 1);
            else
                profile.AddAttribute("Magazines", 0);

            if (data.Contains("Newspapers"))
                profile.AddAttribute("Newspapers", 1);
            else
                profile.AddAttribute("Newspapers", 0);

            if (data.Contains("Specialist books"))
                profile.AddAttribute("Specialist books", 1);
            else
                profile.AddAttribute("Specialist books", 0);

            if (data.Contains("eBooks"))
                profile.AddAttribute("eBooks", 1);
            else
                profile.AddAttribute("eBooks", 0);
        }

        private void ProcessBookGenres(IdentifiableDataPoint profile, string[] data, int fieldIndex, int rowIndex)
        {
            if (data.Contains("Novels"))
                profile.AddAttribute("Novels", 1);
            else
                profile.AddAttribute("Novels", 0);

            if (data.Contains("Thrillers"))
                profile.AddAttribute("Thrillers", 1);
            else
                profile.AddAttribute("Thrillers", 0);

            if (data.Contains("Comedies"))
                profile.AddAttribute("Comedies", 1);
            else
                profile.AddAttribute("Comedies", 0);

            if (data.Contains("Biographies"))
                profile.AddAttribute("Biographies", 1);
            else
                profile.AddAttribute("Biographies", 0);

            if (data.Contains("Comics"))
                profile.AddAttribute("Comics", 1);
            else
                profile.AddAttribute("Comics", 0);

            if (data.Contains("Scientific articles"))
                profile.AddAttribute("Scientific articles", 1);
            else
                profile.AddAttribute("Scientific articles", 0);
        }

        private void ProcessFilmGenres(IdentifiableDataPoint profile, string[] data, int fieldIndex, int rowIndex)
        {
            if (data.Contains("Crime and gangster"))
                profile.AddAttribute("Crime and gangster", 1);
            else
                profile.AddAttribute("Crime and gangster", 0);

            if (data.Contains("Comedies"))
                profile.AddAttribute("Comedies", 1);
            else
                profile.AddAttribute("Comedies", 0);

            if (data.Contains("Dramas"))
                profile.AddAttribute("Dramas", 1);
            else
                profile.AddAttribute("Dramas", 0);

            if (data.Contains("Sport"))
                profile.AddAttribute("Sport", 1);
            else
                profile.AddAttribute("Sport", 0);

            if (data.Contains("Thrillers"))
                profile.AddAttribute("Thrillers", 1);
            else
                profile.AddAttribute("Thrillers", 0);

            if (data.Contains("Documentaries"))
                profile.AddAttribute("Documentaries", 1);
            else
                profile.AddAttribute("Documentaries", 0);

            if (data.Contains("Romantic films"))
                profile.AddAttribute("Romantic films", 1);
            else
                profile.AddAttribute("Romantic films", 0);

            if (data.Contains("Art film"))
                profile.AddAttribute("Art film", 1);
            else
                profile.AddAttribute("Art film", 0);
        }

        private void ProcessRelationshipStatus(IdentifiableDataPoint profile, string data, int fieldIndex, int rowIndex)
        {
            if ("Single".Equals(data))
                profile.AddAttribute("Single", 1);
            else
                profile.AddAttribute("Single", 0);

            if ("Married".Equals(data))
                profile.AddAttribute("Married", 1);
            else
                profile.AddAttribute("Married", 0);

            if ("In a relationsship, but unmarried".Equals(data) || "In a relationsship".Equals(data) || "but unmarried".Equals(data))
                profile.AddAttribute("In a relationsship, but unmarried", 1);
            else
                profile.AddAttribute("In a relationsship, but unmarried", 0);

            if ("It's complicated".Equals(data))
                profile.AddAttribute("It's complicated", 1);
            else
                profile.AddAttribute("It's complicated", 0);

            if ("Divorced".Equals(data))
                profile.AddAttribute("Divorced", 1);
            else
                profile.AddAttribute("Divorced", 0);
        }

        private void ProcessGadgets(IdentifiableDataPoint profile, string[] data, int fieldIndex, int rowIndex)
        {
            if (data.Contains("A smartphone"))
                profile.AddAttribute("A smartphone", 1);
            else
                profile.AddAttribute("A smartphone", 0);

            if (data.Contains("A tablet"))
                profile.AddAttribute("A tablet", 1);
            else
                profile.AddAttribute("A tablet", 0);

            if (data.Contains("An MP3-player"))
                profile.AddAttribute("An MP3-player", 1);
            else
                profile.AddAttribute("An MP3-player", 0);

            if (data.Contains("A PC, Mac or laptop") || data.Contains("A PC or laptop") || data.Contains("A PC") || data.Contains("Mac or laptop"))
                profile.AddAttribute("A PC, Mac or laptop", 1);
            else
                profile.AddAttribute("A PC, Mac or laptop", 0);

            if (data.Contains("An eBook-reader"))
                profile.AddAttribute("An eBook-reader", 1);
            else
                profile.AddAttribute("An eBook-reader", 0);
        }

        private void ProcessHousingType(IdentifiableDataPoint profile, string data, int fieldIndex, int rowIndex)
        {
            if ("In a mansion or larger home".Equals(data))
                profile.AddAttribute("In a mansion or larger home", 1);
            else
                profile.AddAttribute("In a mansion or larger home", 0);

            if ("In a house".Equals(data))
                profile.AddAttribute("In a house", 1);
            else
                profile.AddAttribute("In a house", 0);

            if ("In an apartment".Equals(data))
                profile.AddAttribute("In an apartment", 1);
            else
                profile.AddAttribute("In an apartment", 0);

            if ("In a shared apartment".Equals(data))
                profile.AddAttribute("In a shared apartment", 1);
            else
                profile.AddAttribute("In a shared apartment", 0);

            if ("On a boat".Equals(data))
                profile.AddAttribute("On a boat", 1);
            else
                profile.AddAttribute("On a boat", 0);

            if ("Homeless".Equals(data))
                profile.AddAttribute("Homeless", 1);
            else
                profile.AddAttribute("Homeless", 0);
        }

        private void ProcessHouseholdControl(IdentifiableDataPoint profile, string data, int fieldIndex, int rowIndex)
        {
            if ("Yes".Equals(data))
                profile.AddAttribute("Household Control", 1);
            else if ("No".Equals(data))
                profile.AddAttribute("Household Control", 0);
            else if ("Partially".Equals(data))
                profile.AddAttribute("Household Control", 0.5);
        }

        private void ProcessHouseholdSize(IdentifiableDataPoint profile, string data, int fieldIndex, int rowIndex)
        {
            if ("I live alone".Equals(data))
                profile.AddAttribute("I live alone", 1);
            else
                profile.AddAttribute("I live alone", 0);

            if ("Two".Equals(data))
                profile.AddAttribute("Two", 1);
            else
                profile.AddAttribute("Two", 0);

            if ("Three".Equals(data))
                profile.AddAttribute("Three", 1);
            else
                profile.AddAttribute("Three", 0);

            if ("Four or more".Equals(data))
                profile.AddAttribute("Four or more", 1);
            else
                profile.AddAttribute("Four or more", 0);
        }

        private void ProcessChildren(IdentifiableDataPoint profile, string data, int fieldIndex, int rowIndex)
        {
            if ("None".Equals(data))
                profile.AddAttribute("None", 1);
            else
                profile.AddAttribute("None", 0);

            if ("One".Equals(data))
                profile.AddAttribute("One", 1);
            else
                profile.AddAttribute("One", 0);

            if ("Two".Equals(data))
                profile.AddAttribute("Two", 1);
            else
                profile.AddAttribute("Two", 0);

            if ("Three".Equals(data))
                profile.AddAttribute("Three", 1);
            else
                profile.AddAttribute("Three", 0);

            if ("Four or more".Equals(data))
                profile.AddAttribute("Four or more", 1);
            else
                profile.AddAttribute("Four or more", 0);
        }

        private void ProcessSalary(IdentifiableDataPoint profile, string data, int fieldIndex, int rowIndex)
        {
            if ("Less than 750 €".Equals(data))
                profile.AddAttribute("Salary", 0.1429);
            else if ("750 -1000 €".Equals(data))
                profile.AddAttribute("Salary", 0.2858);
            else if ("1000 - 1500 €".Equals(data))
                profile.AddAttribute("Salary", 0.4287);
            else if ("1500 - 2000 €".Equals(data))
                profile.AddAttribute("Salary", 0.5716);
            else if ("2000 - 3000 €".Equals(data))
                profile.AddAttribute("Salary", 0.7145);
            else if ("3000 - 4000 €".Equals(data))
                profile.AddAttribute("Salary", 0.8574);
            else if ("More than 4000 €".Equals(data))
                profile.AddAttribute("Salary", 1);
            else
                profile.AddAttribute("Salary", 0);
        }

        private void ProcessMajorPurchase(IdentifiableDataPoint profile, string data, int fieldIndex, int rowIndex)
        {
            if ("Let your emotions alone decide".Equals(data))
                profile.AddAttribute("Major Purchase", 0);
            else if ("Let emotions decide more than rational thought".Equals(data))
                profile.AddAttribute("Major Purchase", 0.25);
            else if ("Let rational thought decide more than emotions".Equals(data))
                profile.AddAttribute("Major Purchase", 0.75);
            else if ("Let rational thought decide completely".Equals(data))
                profile.AddAttribute("Major Purchase", 1);
            else if ("Both - 50/50".Equals(data))
                profile.AddAttribute("Major Purchase", 0.50);
        }

        private void ProcessPurchaseDecision(IdentifiableDataPoint profile, string data, int fieldIndex, int rowIndex)
        {
            if ("The price".Equals(data))
                profile.AddAttribute("The price", 1);
            else
                profile.AddAttribute("The price", 0);

            if ("The brand".Equals(data))
                profile.AddAttribute("The brand", 1);
            else
                profile.AddAttribute("The brand", 0);

            if ("Test results and reviews".Equals(data))
                profile.AddAttribute("Test results and reviews", 1);
            else
                profile.AddAttribute("Test results and reviews", 0);

            if ("The store".Equals(data))
                profile.AddAttribute("The store", 1);
            else
                profile.AddAttribute("The store", 0);

            if ("The envy of others".Equals(data))
                profile.AddAttribute("The envy of others", 1);
            else
                profile.AddAttribute("The envy of others", 0);
        }

        private void ProcessBirthYear(IdentifiableDataPoint profile, double data, int fieldIndex, int rowIndex)
        {
            double age;
            age = (DateTime.Now.Year - data) / 100;
            profile.AddAttribute("Age", age);
        }
    }
}