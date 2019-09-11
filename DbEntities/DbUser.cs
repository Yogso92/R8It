using System;

namespace DbEntities
{
    public class DbUser
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public int CountryId { get; set; }
        public string Password { get; set; }
    }
}
