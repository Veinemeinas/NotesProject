using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesProject.Model;
using NotesProject.Repositories;
using NotesProject.Services;

namespace NotesProject.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly CategoriesRepository _categoriesRepository;
        private readonly UserService _userService;
        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(CategoriesRepository categoriesRepository, UserService userService)
        {
            _categoriesRepository = categoriesRepository;
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Category.UserId = _userService.GetUserId();
            _categoriesRepository.CreateCategory(Category);
            return RedirectToPage("Index");
        }
    }
}
