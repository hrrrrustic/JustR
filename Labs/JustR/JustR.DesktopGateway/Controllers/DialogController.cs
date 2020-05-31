using System;
using System.Collections.Generic;
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
            new RestClient(ServiceConfigurations.DialogServiceUri)
                .UseNewtonsoftJson();

        private readonly IRestClient _profileClient =
            new RestClient(ServiceConfigurations.ProfileServiceUri)
                .UseNewtonsoftJson();

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
        public async Task<ActionResult<List<DialogPreviewDto>>> GetDialogs([FromQuery] Guid userId, Int32? offset, Int32 count)
        {
            IRestRequest request = new RestRequest("preview")
                .AddQueryParameter("userId", userId)
                .AddQueryParameter("count", count)
                .AddQueryParameter("offset", offset ?? 0);

            // TODO : null?
            var dialogs = await _dialogClient.GetAsync<List<Dialog>>(request);
            
            List<DialogPreviewDto> result = new List<DialogPreviewDto>(dialogs.Count);

            foreach (Dialog dialog in dialogs)
            {
                request.Parameters.Clear();

                request.AddQueryParameter("userId", dialog.FirstUserId == userId ? dialog.SecondUserid : dialog.FirstUserId);

                User user = await _profileClient.GetAsync<User>(request);

                DialogPreviewDto dto = DialogPreviewDto.FromDialogAndUser(dialog, user);

                result.Add(dto);
            }

            return Ok(result);
        }
        
        [HttpGet]
        public async Task<ActionResult<DialogInfoDto>> GetDialog([FromQuery] Guid dialogId, Guid userId)
        {
            IRestRequest request = new RestRequest()
                .AddQueryParameter("dialogId", dialogId);

            Dialog dialog = await _dialogClient.GetAsync<Dialog>(request);

            if (dialog is null)
                return BadRequest();

            request = new RestRequest("preview");
            request.AddQueryParameter("userId", dialog.FirstUserId == userId ? dialog.SecondUserid : dialog.FirstUserId);

            User interlocutor = await _profileClient.GetAsync<User>(request);

            DialogInfoDto dto = new DialogInfoDto
            {
                DialogId = dialog.DialogId,
                Interlocutor = UserPreviewDto.FromUser(interlocutor)
            };

            return Ok(dto);

        }

        [HttpPost]
        public async Task<ActionResult<DialogInfoDto>> CreateDialog([FromQuery] Guid firstUserId, Guid secondUserId)
        {
            IRestRequest request = new RestRequest()
                .AddQueryParameter("firstUserId", firstUserId)
                .AddQueryParameter("secondUserId", secondUserId);

            User interlocutor = await _profileClient.GetAsync<User>(request);

            if (interlocutor is null)
                return BadRequest();

            // TODO : кажется там может null прилететь в ответ
            Dialog newDialog = await _dialogClient.PostAsync<Dialog>(request);

            // TODO : нужно переместтить вверх к запросу юзера
            request = new RestRequest("preview") 
                .AddQueryParameter("userId",
                    newDialog.FirstUserId == firstUserId ? newDialog.SecondUserid : newDialog.FirstUserId);


            DialogInfoDto dto = new DialogInfoDto
            {
                DialogId = newDialog.DialogId,
                Interlocutor = UserPreviewDto.FromUser(interlocutor)
            };

            return Ok(dto);
        }
    }
}
