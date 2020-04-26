using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.Models.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JustR.FriendService
{
    public class FriendController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<UserPreviewDto>> GetUserFriends(Guid userId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult<FriendRequestDto> CreateFriendRequest(FriendRequestDto dto)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public ActionResult<FriendRequestDto> CreateFriendResponse(FriendRequestDto dto)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult DeleteFriend(Guid userId, Guid secondUserId)
        {
            throw new NotImplementedException();
        }
    }
}