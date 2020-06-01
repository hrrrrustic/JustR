﻿using System;
using JustR.Core.Enum;
using JustR.Models.Entity;

namespace JustR.Core.Dto
{
    public class FriendRequestDto
    {
        public Guid FirstUserId { get; }
        public Guid SecondUserId { get; }
        public RelationshipState State { get; }

        private FriendRequestDto(Guid firstUserId, Guid secondUserId, RelationshipState state)
        {
            FirstUserId = firstUserId;
            SecondUserId = secondUserId;
            State = state;
        }
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
            FriendRequestDto dto =
                new FriendRequestDto(relationship.FirstUserId, relationship.SecondUserId, relationship.State);

            return dto;
        }

        public static FriendRequestDto OutputFriendRequest(Guid firstUserId, Guid secondUserId)
        {
            return new FriendRequestDto(firstUserId, secondUserId, RelationshipState.OutputFriendRequest);
        }

        public static FriendRequestDto InputFriendRequest(Guid firstUserId, Guid secondUserId)
        {
            return new FriendRequestDto(firstUserId, secondUserId, RelationshipState.InputFriendRequest);
        }
    }
}
