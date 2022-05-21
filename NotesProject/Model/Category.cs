using System.ComponentModel.DataAnnotations;

namespace NotesProject.Model
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public List<Note> Notes { get; set; }
        public string UserId { get; set; }
    }
}
