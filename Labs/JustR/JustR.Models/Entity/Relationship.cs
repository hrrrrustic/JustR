using System;
using JustR.Models.Enum;

namespace JustR.Models.Entity
{
    public class Relationship
    {
        public Guid FirstUserId { get; set; }
        public Guid SecondUserId { get; set; }
        public RelationshipState State { get; set; }
        
    }
}