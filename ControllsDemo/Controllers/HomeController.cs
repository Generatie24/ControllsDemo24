using ControllsDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace ControllsDemo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new MyViewModel
            {
                DepartmentItems = GetDepartmentItems()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult SubmitForm(MyViewModel model)
        {
            model.DepartmentItems = GetDepartmentItems();

            if (ModelState.IsValid)
            {
                var selectedDepartment = model.DepartmentItems.FirstOrDefault(x => x.Value == model.SelectedDepartmentId.ToString());
                model.SelectedDepartmentText = selectedDepartment?.Text ?? "Selecteer een afdeling";
            }

            if (model.Cat.IsActive)
            {
                ViewBag.IsCatActive = "Check box selected"; 
            }
            else
            {
                ViewBag.IsCatActive = "Check box NOT selected";
            }

            ViewBag.Radio = model.Department?.SelectedOption;

            return View("Index",model);
        }

        private List<SelectListItem> GetDepartmentItems()
        {

            var itemsFromDb = GetItems().ToList();

            // convert to SelectListItem
            var selectListItems = itemsFromDb.Select(x => new SelectListItem
            {
                Value = x.Value,
                Text = x.Text
            }).ToList();

            return selectListItems;
        }


        // ophalen data van database
        private List<SelectListItem> GetItems()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Optie 1" },
                new SelectListItem { Value = "2", Text = "Optie 2" },
                new SelectListItem { Value = "3", Text = "Optie 3" }
            };
        }

    }
}
