using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesProject.Model;
using NotesProject.Repositories;
using NotesProject.Services;

namespace NotesProject.Pages.Categories
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly CategoriesRepository _categoriesRepository;
        private readonly UserService _userService;

        public List<Category> Categories { get; set; }
        [BindProperty]
        public string Search { get; set; }

        public IndexModel(CategoriesRepository categoriesRepository, UserService userService)
        {
            _categoriesRepository = categoriesRepository;
            _userService = userService;
        }

        public void OnGet()
        {
            var userId = _userService.GetUserId();
            Categories = _categoriesRepository.GetCategories(userId);
        }

        public IActionResult OnPostDelete(int id)
        {
            var userId = _userService.GetUserId();
            _categoriesRepository.RemoveCategory(id, userId);
            return RedirectToPage("Index");
        }
    }
}
