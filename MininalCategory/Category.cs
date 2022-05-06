namespace MininalCategory
{
    public class Category
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        public Category()
        {
            UpdatedAt = DateTime.UtcNow;
        }
        public Category(Category category,DateTime? deletedAt)
        {
            Name = category.Name;
            DisplayOrder = category.DisplayOrder;
            DeletedAt = deletedAt;
        }
    }
}
