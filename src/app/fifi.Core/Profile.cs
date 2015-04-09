using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class Profile
    {
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
