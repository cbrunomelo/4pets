
namespace Domain.Entitys
{
    public class Category : Entity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public List<Product> Products { get; private set; }



        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public void Update(Category category)
        {
            Name = category.Name;
            Description = category.Description;
        }
    }
}