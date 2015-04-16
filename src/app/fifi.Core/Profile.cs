using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fifi.Core.Algorithms;

namespace fifi.Core
{
    public class Profile : DataPoint
    {
        private IList<LabeledValue> values;
        public int Id { get; set; }

        public Profile()
        {
            values = new List<LabeledValue>();
        }

        public void AddValue(string label, double value)
        {
            values.Add(new LabeledValue(label, value));
        }

        public LabeledValue this[string label]
        {
            get
            {
                return values.Where(v => v.Label == label).FirstOrDefault();
            }
        }

        public int CountValues
        {
            get { return values.Count; }
        }

        public double[] Values
        {
            get { return values.Select(v => v.Value).ToArray(); }
        }

        public Centroid ClosestCentroid { get; set; }

        public string CreatedAt { get; set; }
        public string Gender { get; set; }
        public string EmploymentStatus { get; set; }
        public string[] ReadingHabits { get; set; }
        public string[] BookGenres { get; set; }
        public string[] FilmGenres { get; set; }
        public string RelationshipStatus { get; set; }
        public string HouseholdSize { get; set; }
        public string[] Gadgets { get; set; }
        public string Children { get; set; }
        public string HousingType { get; set; }
        public string HouseholdControl { get; set; }
        public string Salary { get; set; }
        public string MajorPurchase { get; set; }
        public string PurchaseDecision { get; set; }
        public int BirthYear { get; set; }
    }
}
