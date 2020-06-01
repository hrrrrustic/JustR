using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.Core.Dto;
using JustR.Core.Entity;
using Microsoft.AspNetCore.Mvc;
using JustR.Core.Extensions;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.DesktopGateway.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DialogController : Controller
    {
        private readonly IRestClient _dialogClient =
            new RestClient(ServiceConfigurations.DialogServiceUrl)
                .UseNewtonsoftJson();

        private readonly IRestClient _profileClient =
            new RestClient(ServiceConfigurations.ProfileServiceUrl)
                .UseNewtonsoftJson();

        #region HTTP GET

        [HttpGet("id")]
        public async Task<ActionResult<Guid>> GetDialogId([FromQuery] Guid firstUserId, Guid secondUserid)
        {
            IRestRequest request = new RestRequest("id")
                .AddQueryParameter("firstUserId", firstUserId)
                .AddQueryParameter("secondUserId", secondUserid);

            Guid id = await _dialogClient.GetAsync<Guid>(request);

            return Ok(id);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IReadOnlyList<DialogPreviewDto>>> GetDialogs([FromQuery] Guid userId, Int32? offset, Int32 count)
        {
            IRestRequest request = new RestRequest("preview")
                .AddQueryParameter("userId", userId)
                .AddQueryParameter("count", count)
                .AddQueryParameter("offset", offset ?? 0);

            IReadOnlyList<Dialog> dialogs = await _dialogClient.GetAsync<List<Dialog>>(request);
            if (dialogs is null)
                return BadRequest();

            request = new RestRequest("previews");

            foreach (Dialog dialog in dialogs)
                request.AddQueryParameter("usersId", dialog.GetInterlocutorId(userId));

            IReadOnlyList<User> users = await _profileClient.GetAsync<List<User>>(request);

            IReadOnlyList<DialogPreviewDto> previews = dialogs
                .Zip(users, DialogPreviewDto.FromDialogAndUser)
                .ToList();

            return Ok(previews);
        }
        
        [HttpGet]
        public async Task<ActionResult<DialogInfoDto>> GetDialog([FromQuery] Guid dialogId, Guid userId)
        {
            IRestRequest request = new RestRequest()
                .AddQueryParameter("dialogId", dialogId);

            Dialog dialog = await _dialogClient.GetAsync<Dialog>(request);

            if (dialog is null)
                return BadRequest();

            request = new RestRequest("preview")
                .AddQueryParameter("userId", dialog.GetInterlocutorId(userId));

            User interlocutor = await _profileClient.GetAsync<User>(request);

            DialogInfoDto dto = new DialogInfoDto(dialog.DialogId, UserPreviewDto.FromUser(interlocutor));

            return Ok(dto);
        }

        #endregion

        #region HTTP POST

        [HttpPost]
        public async Task<ActionResult<DialogInfoDto>> CreateDialog([FromQuery] Guid firstUserId, Guid secondUserId)
        {

            IRestRequest request = new RestRequest("preview")
                .AddQueryParameter("userId", firstUserId);

            User interlocutor = await _profileClient.GetAsync<User>(request);

            if (interlocutor is null)
                return BadRequest();

            request = new RestRequest()
                .AddQueryParameter("firstUserId", firstUserId)
                .AddQueryParameter("secondUserId", secondUserId);

            Dialog newDialog = await _dialogClient.PostAsync<Dialog>(request);

            DialogInfoDto dto = new DialogInfoDto(newDialog.DialogId, UserPreviewDto.FromUser(interlocutor));

            return Ok(dto);
        }

        #endregion
    }
}
