using Business_Platform.Model.Food;
using Business_Platform.Model.Office;
using Business_Platform.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.DTOs
{
    public class UserGet
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime RegisterDate { get; set; }
        public string? StateName { get; set; } // Include State name
        public string? OfficeCompanyName { get; set; } // Include OfficeCompany name
        public string? OfficeCompanyBranchName { get; set; } // Include OfficeCompanyBranch name
        public string? MainCompanyName { get; set; } // Include MainCompany name
        public string? FoodCompanyName { get; set; } // Include FoodCompany name
        public string? RestaurantBranchName { get; set; } // Include RestaurantBranch name
    }
}
