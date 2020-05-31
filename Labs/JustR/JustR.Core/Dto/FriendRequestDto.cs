using System;
using JustR.Core.Enum;
using JustR.Models.Entity;

namespace JustR.Core.Dto
{
    public class FriendRequestDto
    {
        public Guid FirstUserId { get; set; }
        public Guid SecondUserId { get; set; }
        public RelationshipState State { get; set; }

        public Relationship ToRelationship()
        {
            Relationship relationship = new Relationship
            {
                FirstUserId = FirstUserId,
                SecondUserId = SecondUserId,
                State = State
            };

            return relationship;
        }

        public static FriendRequestDto FromRelationship(Relationship relationship)
        {
            FriendRequestDto dto = new FriendRequestDto
            {
                FirstUserId = relationship.FirstUserId,
                SecondUserId = relationship.SecondUserId,
                State = relationship.State
            };

            return dto;
        }
    }
}
