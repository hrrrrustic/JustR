using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.Core.Entity;
using Microsoft.AspNetCore.Mvc;
using JustR.Core.Extensions;
using JustR.DialogService.InternalApi;
using JustR.ProfileService.InternalApi;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using JustR.ClientRelatedShare.Dto;

namespace JustR.DesktopGateway.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DialogController : Controller
    {
        private readonly IDialogApiProvider _dialogApiProvider = new HttpDialogApiProvider(ServiceConfigurations.DialogServiceUrl);

        private readonly IProfileApiProvider _profileApiProvider = new HttpProfileApiProvider(ServiceConfigurations.ProfileServiceUrl);

        #region HTTP GET

        [HttpGet("id")]
        public async Task<ActionResult<Guid>> GetDialogId([FromQuery] Guid firstUserId, Guid secondUserId)
        {
            Guid id = await _dialogApiProvider.GetDialogId(firstUserId, secondUserId);

            return Ok(id);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IReadOnlyList<DialogPreviewDto>>> GetDialogs([FromQuery] Guid userId, Int32? offset, Int32 count)
        {
            IReadOnlyList<Dialog> dialogs = await _dialogApiProvider.GetDialogsPreview(userId, offset ?? 0, count);

            if (dialogs is null)
                return BadRequest();

            IReadOnlyList<User> users = await _profileApiProvider.GetUsersPreview(dialogs.Select(k => k.GetInterlocutorId(userId)));
            
            IReadOnlyList<DialogPreviewDto> previews = dialogs
                .Zip(users, DialogPreviewDto.FromDialogAndUser)
                .ToList();

            return Ok(previews);
        }
        
        [HttpGet]
        public async Task<ActionResult<DialogInfoDto>> GetDialog([FromQuery] Guid dialogId, Guid userId)
        {
            Dialog dialog = await _dialogApiProvider.GetDialog(dialogId);

            if (dialog is null)
                return BadRequest();

            User interlocutor = await _profileApiProvider.GetUserProfile(userId);

            DialogInfoDto dto = new DialogInfoDto(dialog.DialogId, UserPreviewDto.FromUser(interlocutor));

            return Ok(dto);
        }

        #endregion

        #region HTTP POST

        [HttpPost]
        public async Task<ActionResult<DialogInfoDto>> CreateDialog([FromQuery] Guid firstUserId, Guid secondUserId)
        {
            User interlocutor = await _profileApiProvider.GetUserPreview(firstUserId);

            if (interlocutor is null)
                return BadRequest();

            Dialog newDialog = await _dialogApiProvider.CreateDialog(firstUserId, secondUserId);

            DialogInfoDto dto = new DialogInfoDto(newDialog.DialogId, UserPreviewDto.FromUser(interlocutor));

            return Ok(dto);
        }

        #endregion
    }
}
