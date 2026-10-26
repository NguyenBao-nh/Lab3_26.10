using Lab3_26._10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Reflection;

namespace Lab3_26._10.Controllers
{
    public class HomeController : Controller
    {
        private List<Student> listStudent = new List<Student>();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranchs = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "IT" },
                new SelectListItem { Text = "Business", Value = "Business" },
                new SelectListItem { Text = "Language", Value = "Language" }
            };
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                // Safely calculate the next ID
                int nextId = listStudent.Any() ? listStudent.Last().Id + 1 : 1;
                student.Id = nextId;

                listStudent.Add(student);
                return View("Index", listStudent);
            }

            // Repopulate dropdowns/radio buttons if validation fails
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranchs = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "IT" },
                new SelectListItem { Text = "Bussiness", Value = "Bussiness" },
                new SelectListItem { Text = "Language", Value = "Language" }
            };

            return View(student);
        }
    }
}
