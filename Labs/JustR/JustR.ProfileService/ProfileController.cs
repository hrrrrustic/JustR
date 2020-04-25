using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.Models.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JustR.ProfileService
{
    public class ProfileController : Controller
    {
        [HttpGet("{userId}")]
        public ActionResult<UserProfileDto> GetUserProfile(Guid userId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("search/{query}")]
        public ActionResult<IEnumerable<UserPreviewDto>> SearchUser(String query)
        {
            throw new NotImplementedException();
        }

        [HttpGet("preview/{userId}")]
        public ActionResult<UserPreviewDto> GetUserPreview(Guid userId) // Что-то на уровне фотка + имя
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public ActionResult<ChangeProfileDto> UpdateUserProfile(ChangeProfileDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
