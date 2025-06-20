using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Todolist.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Todolist.Pages
{
    public class PeopleModel : PageModel
    {
        private readonly MyDbContextcs _context;

        [BindProperty]
        public Person NewPerson { get; set; } = new Person();

        public List<Person> People { get; set; } = new List<Person>();

        public PeopleModel(MyDbContextcs context)
        {
            _context = context;
        }

        public void OnGet()
        {
            People = _context.People.ToList();
        }

        public IActionResult OnGetEdit(int id)
        {
            NewPerson = _context.People.FirstOrDefault(p => p.id == id);
            People = _context.People.ToList(); // important
            return Page();
        }

        public IActionResult OnPost()
        {
            if (NewPerson.id != 0)
            {
                var existing = _context.People.FirstOrDefault(p => p.id == NewPerson.id);
                if (existing != null)
                {
                    existing.Name = NewPerson.Name;
                    existing.Task = NewPerson.Task;
                    existing.StartDate = NewPerson.StartDate;
                    existing.EndDate = NewPerson.EndDate;
                }
            }
            else
            {
                _context.People.Add(NewPerson);
            }

            _context.SaveChanges();
            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            var person = _context.People.FirstOrDefault(p => p.id == id);
            if (person != null)
            {
                _context.People.Remove(person);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}
