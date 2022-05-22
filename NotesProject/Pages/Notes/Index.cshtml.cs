using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesProject.Model;
using NotesProject.Repositories;
using NotesProject.Services;

namespace NotesProject.Pages.Notes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly NotesRepository _notesRepository;
        private readonly UserService _userService;
        [BindProperty]
        public List<Note> Notes { get; set; }
        [BindProperty]
        public int CategoryId { get; set; }
        [BindProperty]
        public string Search { get; set; }
        public IndexModel(NotesRepository notesRepository, UserService userService)
        {
            _notesRepository = notesRepository;
            _userService = userService;
        }

        public void OnGet(int id)
        {
            var userId = _userService.GetUserId();
            Notes = _notesRepository.GetNotes(id, userId);
            CategoryId = id;
        }

        public IActionResult OnPostDelete(int categoryId, int id)
        {
            _notesRepository.RemoveNote(id);
            return RedirectToPage("Index", null, new { id = categoryId });
        }

        /*        public IActionResult OnSearchPost()
                {
                    var userId = _userService.GetUserId();
                    Notes = _notesRepository.SearchNotes(Search, userId);
                    return Page();

                }*/
        public IActionResult OnPostSearch()
        {
            var userId = _userService.GetUserId();
            Notes = _notesRepository.SearchNotes(Search, userId);

            return Page();
        }
    }
}
