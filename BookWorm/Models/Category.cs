namespace BookWorm.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Categories { get; set; }

        public Category(int id, string FileFormat)
        {
            this.Id = id;
            this.Categories = Categories;
        }
        public Category()
        {
        }
    }
}