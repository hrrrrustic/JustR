using System;
using System.Collections.Generic;
using System.Linq;
using JustR.Core.Enum;
using JustR.Models.Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace JustR.FriendService.Repository
{
    public class FriendRepository : IFriendRepository
    {
        private readonly FriendDbContext _context;

        public FriendRepository(FriendDbContext context)
        {
            _context = context;
        }

        public Relationship CreateFriendRequest(Relationship request)
        {
            Relationship res = _context.Relationships.Find(request.FirstUserId, request.SecondUserId);
            if (!(res is null))
            {
                request.State = RelationshipState.Friend;
                return UpdateFriendRequest(request);
            }

            EntityEntry<Relationship> directRelation = _context.Relationships.Add(request);

            Relationship reverseRelation = new Relationship();
            reverseRelation.SecondUserId = request.FirstUserId;
            reverseRelation.FirstUserId = request.SecondUserId;
            reverseRelation.State = RelationshipState.InputFriendRequest;

            _context.Relationships.Add(reverseRelation);
            _context.SaveChanges();

            return directRelation.Entity;
        }

        public IReadOnlyList<Guid> ReadUserFriends(Guid userId)
        {
            return _context
                .Relationships
                .Where(k => k.State == RelationshipState.Friend && k.FirstUserId == userId)
                .Select(k => k.SecondUserId)
                .ToList();
        }

        public Relationship UpdateFriendRequest(Relationship request)
        {
            Relationship relation = _context.Relationships.Find(request.FirstUserId, request.SecondUserId);
            relation.State = request.State;

            Relationship reverseRelation = _context.Relationships.Find(request.SecondUserId, request.FirstUserId);
            reverseRelation.State = request.State;

            _context.SaveChanges();

            return relation;
        }

        public void DeleteFriend(Guid firstUserId, Guid secondUserId)
        {
            Relationship directRequest = _context.Relationships.Find(firstUserId, secondUserId);

            if (directRequest is null || directRequest.State != RelationshipState.Friend)
                return;

            directRequest.State = RelationshipState.InputFriendRequest;

            Relationship reverseRequest = _context.Relationships.Find(secondUserId, firstUserId);
            reverseRequest.State = RelationshipState.OutputFriendRequest;

            _context.SaveChanges();
        }
    }
}