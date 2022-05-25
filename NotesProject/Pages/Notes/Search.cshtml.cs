using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesProject.Model;
using NotesProject.Repositories;
using NotesProject.Services;

namespace NotesProject.Pages.Notes
{
    public class SearchModel : PageModel
    {
        private readonly NotesRepository _notesRepository;
        private readonly UserService _userService;
        [BindProperty]
        public List<Note> Notes { get; set; }
        [BindProperty]
        public string Search { get; set; }

        public SearchModel(NotesRepository notesRepository, UserService userService)
        {
            _notesRepository = notesRepository;
            _userService = userService;
        }

        public IActionResult OnPostSearch()
        {
            var userId = _userService.GetUserId();
            Notes = _notesRepository.SearchNotes(Search, userId);
            return Page();
        }
    }
}
