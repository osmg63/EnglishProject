﻿namespace EnglishProject.Data.Entities
{
    public class User
    {

        
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName {  get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<Transaction> Transactions { get; set; }



    }
}
