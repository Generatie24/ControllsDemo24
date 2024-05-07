using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ControllsDemo.Models
{
    public class MyViewModel
    {
        public int Id { get; set; }
        public Department? Department { get; set; }
        public Cat? Cat { get; set; }


        [Required(ErrorMessage = "Selecteer een afdeling")]
        public int? SelectedDepartmentId { get; set; }
        public string SelectedDepartmentText { get; set; } = string.Empty;
        
        public List<SelectListItem>? DepartmentItems { get; set; }

        public int SelectedCatId { get; set; }
        public string SelectedCatText { get; set; } = string.Empty;
        public List<SelectListItem>? CatItems { get; set; }

    }
}
