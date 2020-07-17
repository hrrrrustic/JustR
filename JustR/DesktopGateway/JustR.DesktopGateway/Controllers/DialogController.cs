using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.Core.Entity;
using JustR.DesktopGateway.PublicApi;
using JustR.DialogService.InternalApi;
using JustR.ProfileService.InternalApi;
using Microsoft.AspNetCore.Mvc;

namespace JustR.DesktopGateway.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/" + DesktopGatewayHttpEndpoints.DialogEndpoints.ControllerEndpoint)]
    public class DialogController : Controller
    {
        private readonly IDialogApiProvider _dialogApiProvider;

        private readonly IProfileApiProvider _profileApiProvider;

        public DialogController(IProfileApiProvider profileApiProvider, IDialogApiProvider dialogApiProvider)
        {
            _profileApiProvider = profileApiProvider;
            _dialogApiProvider = dialogApiProvider;
        }

        #region HTTP POST

        [HttpPost(DesktopGatewayHttpEndpoints.DialogEndpoints.CreateDialog)]
        public async Task<ActionResult<DialogInfoDto>> CreateDialog([FromQuery] Guid firstUserId, Guid secondUserId)
        {
            User interlocutor = await _profileApiProvider.GetUserPreview(firstUserId);

            //TODO : Больше инфы
            if (interlocutor is null)
                return BadRequest();

            Dialog newDialog = await _dialogApiProvider.CreateDialog(firstUserId, secondUserId);

            DialogInfoDto dto = new DialogInfoDto(newDialog.DialogId, UserPreviewDto.FromUser(interlocutor));

            return Ok(dto);
        }

        #endregion

        #region HTTP GET

        [HttpGet(DesktopGatewayHttpEndpoints.DialogEndpoints.GetDialogId)]
        public async Task<ActionResult<Guid>> GetDialogId([FromQuery] Guid firstUserId, Guid secondUserId)
        {
            Guid id = await _dialogApiProvider.GetDialogId(firstUserId, secondUserId);

            return Ok(id);
        }

        [HttpGet(DesktopGatewayHttpEndpoints.DialogEndpoints.GetDialogs)]
        public async Task<ActionResult<IReadOnlyList<DialogPreviewDto>>> GetDialogs([FromQuery] Guid userId,
            Int32? offset, Int32 count)
        {
            IReadOnlyList<Dialog> dialogs = await _dialogApiProvider.GetDialogsPreview(userId, count, offset ?? 0);

            IEnumerable<Guid> dialogsId = dialogs.Select(k => k.GetInterlocutorId(userId));

            IReadOnlyList<User> users =
                await _profileApiProvider.GetUsersPreview(dialogsId);

            IReadOnlyList<DialogPreviewDto> previews = dialogs
                .Zip(users, DialogPreviewDto.FromDialogAndUser)
                .ToList();

            return Ok(previews);
        }

        [HttpGet(DesktopGatewayHttpEndpoints.DialogEndpoints.GetDialog)]
        public async Task<ActionResult<DialogInfoDto>> GetDialog([FromQuery] Guid dialogId, Guid userId)
        {
            Dialog dialog = await _dialogApiProvider.GetDialog(dialogId);

            //TODO : Больше инфы
            if (dialog is null)
                return BadRequest();

            User interlocutor = await _profileApiProvider.GetUserProfile(dialog.GetInterlocutorId(userId));

            DialogInfoDto dto = new DialogInfoDto(dialog.DialogId, UserPreviewDto.FromUser(interlocutor));

            return Ok(dto);
        }

        #endregion
    }
}