using Microsoft.EntityFrameworkCore;
using NotesProject.Data;
using NotesProject.Model;

namespace NotesProject.Repositories
{
    public class CategoriesRepository
    {
        private readonly NotesProjectContext _context;

        public CategoriesRepository(NotesProjectContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories(string id)
        {
            return _context.Categories.Include(c => c.Notes).Where(c => c.UserId == id).ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void RenameCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void RemoveCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            _context.Remove(category);
            _context.SaveChanges();
        }
    }
}
