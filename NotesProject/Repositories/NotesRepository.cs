using NotesProject.Data;
using NotesProject.Model;

namespace NotesProject.Repositories
{
    public class NotesRepository
    {
        private readonly NotesProjectContext _context;

        public NotesRepository(NotesProjectContext context)
        {
            _context = context;
        }

        public List<Note> GetNotes(int id, string userId)
        {
            return _context.Notes.Where(n => n.CategoryId == id && n.UserId == userId).ToList();
        }

        public Note GetNote(int id, string userId)
        {
            return _context.Notes.FirstOrDefault(n => n.Id == id && n.UserId == userId);
        }

        public void CreateNote(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public void EditNote(Note note, string userId)
        {
            var noteSelected = _context.Notes.FirstOrDefault(n => n.Id == note.Id);
            if (noteSelected.UserId == userId)
            {
                _context.Notes.Update(note);
                _context.SaveChanges();
            }
        }

        public void RemoveNote(int id, string userId)
        {
            var note = _context.Notes.FirstOrDefault(c => c.Id == id);
            if (note.UserId == userId)
            {
                _context.Remove(note);
                _context.SaveChanges();
            }
        }

        public List<Note> SearchNotes(string search, string userId)
        {
            return _context.Notes.Where(n => n.Title.Contains(search) && n.UserId == userId).ToList();
        }
    }
}
