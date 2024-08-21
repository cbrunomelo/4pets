namespace Domain.Entitys
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;            
        }
    }
}