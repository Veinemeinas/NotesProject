using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesProject.Model;
using NotesProject.Repositories;
using NotesProject.Services;

namespace NotesProject.Pages.Notes
{
    public class EditModel : PageModel
    {
        private readonly NotesRepository _notesRepository;
        private readonly UserService _userService;
        [BindProperty]
        public Note Note { get; set; }

        public EditModel(NotesRepository notesRepository, UserService userService)
        {
            _notesRepository = notesRepository;
            _userService = userService;
        }

        public void OnGet(int id)
        {
            Note = _notesRepository.GetNote(id);
        }

        public IActionResult OnPost(int id)
        {
            var note = _notesRepository.GetNote(id);

            note.Title = Note.Title;
            note.Content = Note.Content;
            _notesRepository.EditNote(note);
            return RedirectToPage("Index", null, new { id = Note.CategoryId });
        }
    }
}
