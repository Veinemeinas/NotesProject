namespace NotesProject.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<Note> Notes { get; set; }
    }
}
