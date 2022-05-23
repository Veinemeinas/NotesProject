using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesProject.Model;
using NotesProject.Repositories;
using NotesProject.Services;
using System.Web;

namespace NotesProject.Pages.Notes
{
    public class CreateModel : PageModel
    {
        private readonly NotesRepository _notesRepository;
        private readonly UserService _userService;
        [BindProperty]
        public Note Note { get; set; }
        [BindProperty]
        public int CategoryId { get; set; }
        public CreateModel(NotesRepository notesRepository, UserService userService)
        {
            _notesRepository = notesRepository;
            _userService = userService;
        }

        public void OnGet(int noteCategory)
        {
            CategoryId = noteCategory;
            Note = new Note() { CategoryId = noteCategory };
        }

        public IActionResult OnPost()
        {
            Note.UserId = _userService.GetUserId();
            _notesRepository.CreateNote(Note);
            return RedirectToPage("Index", null, new { id = Note.CategoryId });
        }
    }
}
