namespace MininalCategory
{
    public class Category
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        public Category()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Category(Category category)
        {
            Name = category?.Name;
            DisplayOrder = category.DisplayOrder;
            UpdatedAt = DateTime.Now;
        }

        public void Deleted()
        {
            DeletedAt = DateTime.Now;
        }
    }
}
