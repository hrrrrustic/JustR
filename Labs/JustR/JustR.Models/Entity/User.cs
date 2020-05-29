using System;

namespace JustR.Models.Entity
{
    public class User
    {
        public Guid UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String UniqueTag { get; set; }
        public Byte[] Avatar { get; set; }
    }
}