using System;

namespace TestProject1.unitTest
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public User()
        {
            CreatedAt = DateTime.Now;
        }

        public User(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            CreatedAt = DateTime.Now;
        }
    }
}