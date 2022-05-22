using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesProject.Model;
using NotesProject.Repositories;
using NotesProject.Services;
using System.ComponentModel;

namespace NotesProject.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly CategoriesRepository _categoriesRepository;
        private readonly UserService _userService;
        [DisplayName("Antraštė")]
        [BindProperty]
        public Category Category { get; set; }

        public EditModel(CategoriesRepository categoriesRepository, UserService userService)
        {
            _categoriesRepository = categoriesRepository;
            _userService = userService;
        }

        public void OnGet(int id)
        {
            Category = _categoriesRepository.GetCategory(id);
        }

        public IActionResult OnPost(int id, string categoryName)
        {
            Category.Id = id;
            Category.UserId = _userService.GetUserId();
            _categoriesRepository.RenameCategory(Category);
            return RedirectToPage("Index");
        }
    }
}
