using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.FriendService.Service;
using JustR.Models.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JustR.FriendService
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class FriendController : Controller
    {
        private readonly IFriendService _friendService;
        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Guid>> GetUserFriends(Guid userId)
        {
            return Ok(_friendService.GetFriends(userId));
        }

        [HttpPost]
        public ActionResult<FriendRequestDto> CreateFriendRequest([FromBody] FriendRequestDto dto)
        {

            if (dto is null)
                return BadRequest();

            return Ok(_friendService.CreateFriendRequest(dto));
        }

        [HttpPut]
        public ActionResult<FriendRequestDto> CreateFriendResponse(FriendRequestDto dto)
        {
            if (dto is null)
                return BadRequest();

            return Ok(_friendService.UpdateFriendRequest(dto));
        }

        [HttpDelete]
        public ActionResult DeleteFriend(Guid userId, Guid secondUserId)
        {
            _friendService.DeleteFriend(userId, secondUserId);
            return Ok();
        }
    }
}