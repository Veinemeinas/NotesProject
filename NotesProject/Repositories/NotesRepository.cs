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

        public Note GetNote(int id)
        {
            return _context.Notes.FirstOrDefault(n => n.Id == id);
        }

        public void CreateNote(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public void EditNote(Note note)
        {
            _context.Notes.Update(note);
            _context.SaveChanges();
        }

        public void RemoveNote(int id)
        {
            var note = _context.Notes.FirstOrDefault(c => c.Id == id);
            _context.Remove(note);
            _context.SaveChanges();
        }
    }
}
