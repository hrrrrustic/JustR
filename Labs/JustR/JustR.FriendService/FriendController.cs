using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JustR.FriendService.Service;
using JustR.Models.Dto;
using JustR.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public ActionResult<IEnumerable<Guid>> GetUserFriends([FromQuery] Guid userId)
        {
            List<Guid> usersId = _friendService.GetFriends(userId);

            return Ok(usersId);
        }

        [HttpPost]
        public ActionResult<Relationship> CreateFriendRequest([FromBody] Relationship dto)
        {

            if (dto is null)
                return BadRequest();

            return Ok(_friendService.CreateFriendRequest(dto));
        }

        [HttpPut]
        public ActionResult<Relationship> CreateFriendResponse([FromBody] Relationship dto)
        {
            if (dto is null)
                return BadRequest();

            return Ok(_friendService.UpdateFriendRequest(dto));
        }

        [HttpDelete]
        public ActionResult DeleteFriend([FromBody] Relationship relationship)
        {
            _friendService.DeleteFriend(relationship);
            return Ok();
        }
    }
}