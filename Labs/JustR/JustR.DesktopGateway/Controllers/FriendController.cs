using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace JustR.DesktopGateway.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
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
        public ActionResult<FriendRequestDto> CreateFriendResponse(Guid userId, Guid secondUserId, Boolean state)    
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
