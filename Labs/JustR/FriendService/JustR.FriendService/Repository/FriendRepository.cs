using System;
using System.Collections.Generic;
using System.Linq;
using JustR.Core.Enum;
using JustR.Models.Entity;

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
            var res = _context.Relationships.Find(request.FirstUserId, request.SecondUserId);
            if (res is null)
            {
                request.State = RelationshipState.Friend;
                return UpdateFriendRequest(request);
            }

            var directRelation = _context.Relationships.Add(request);

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
            var relation = _context.Relationships.Find(request.FirstUserId, request.SecondUserId);
            relation.State = request.State;

            var reverseRelation = _context.Relationships.Find(request.SecondUserId, request.FirstUserId);
            reverseRelation.State = request.State;

            _context.SaveChanges();
            
            return relation;
        }

        public void DeleteFriend(Relationship request)
        {
            // ReSharper disable once SimilarAnonymousTypeNearby
            Relationship directRequest = _context.Relationships.Find(new {request.FirstUserId, request.SecondUserId});
            directRequest.State = RelationshipState.InputFriendRequest;

            Relationship reverseRequest = _context.Relationships.Find(new {request.SecondUserId, request.FirstUserId});
            reverseRequest.State = RelationshipState.OutputFriendRequest;

            _context.SaveChanges();
        }
    }
}