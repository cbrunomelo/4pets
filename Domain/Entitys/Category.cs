namespace Domain.Entitys
{
    public class Category : Entity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            Name = name;
        }

        internal void SetId(int id)
        {
            Id = id;
        }
    }
}