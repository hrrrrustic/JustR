using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JustR.Models.Dto;
using JustR.Models.Entity;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.WebEncoders.Testing;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace JustR.DesktopGateway.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DialogController : Controller
    {
        private readonly RestClient _dialogClient = new RestClient(ServiceConfigurations.DialogServiceUri);

        private readonly RestClient _profileClient = new RestClient(ServiceConfigurations.ProfileServiceUri);

        public DialogController()
        {
            _dialogClient.UseNewtonsoftJson();
            _profileClient.UseNewtonsoftJson();
        }

        [HttpGet("id")]
        public async Task<ActionResult<Guid>> GetDialogId([FromQuery] Guid firstUserId, Guid secondUserid)
        {
            var request = new RestRequest("id");
            request
                .AddParameter("firstUserId", firstUserId, ParameterType.QueryString)
                .AddParameter("secondUserId", secondUserid, ParameterType.QueryString);

            var id = await _dialogClient.GetAsync<Guid>(request);

            return Ok(id);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<DialogPreviewDto>>> GetDialogs([FromQuery] Guid userId, Int32? offset, Int32 count)
        {
            var request = new RestRequest("preview");
            request
                .AddParameter("userId", userId, ParameterType.QueryString)
                .AddParameter("count", count, ParameterType.QueryString)
                .AddParameter("offset", offset ?? 0, ParameterType.QueryString);

            var dialogs = await _dialogClient.GetAsync<List<Dialog>>(request);
            
            List<DialogPreviewDto> result = new List<DialogPreviewDto>(dialogs.Count);

            foreach (Dialog dialog in dialogs)
            {
                request.Parameters.Clear();

                request.AddParameter("userId", dialog.FirstUserId == userId ? dialog.SecondUserid : dialog.FirstUserId);

                var user = await _profileClient.GetAsync<User>(request);

                DialogPreviewDto dto = new DialogPreviewDto
                {
                    DialogId = dialog.DialogId,

                    LastMessageText = dialog.LastMessageText,
                    LastMessageTime = dialog.LastMessageTime,
                    InterlocutorPreview = UserPreviewDto.FromUser(user)
                };

                result.Add(dto);
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<DialogInfoDto>> GetDialog([FromQuery] Guid dialogId, Guid userId)
        {
            var request = new RestRequest();
            request.AddParameter("dialogId", dialogId);

            var dialog = await _dialogClient.GetAsync<Dialog>(request);

            if (dialog is null)
                return BadRequest();


            request = new RestRequest("preview");
            request.AddParameter("userId", dialog.FirstUserId == userId ? dialog.SecondUserid : dialog.FirstUserId);

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
                var request = new RestRequest();
            request
                .AddParameter("firstUserId", firstUserId, ParameterType.QueryString)
                .AddParameter("secondUserId", secondUserId, ParameterType.QueryString);

            User interlocutor = await _profileClient.GetAsync<User>(request);
            if (interlocutor is null)
                return BadRequest();

            var newDialog = await _dialogClient.PostAsync<Dialog>(request);

            request = new RestRequest("preview");
            request.AddParameter("userId", newDialog.FirstUserId == firstUserId ? newDialog.SecondUserid : newDialog.FirstUserId);


            DialogInfoDto dto = new DialogInfoDto
            {
                DialogId = newDialog.DialogId,
                Interlocutor = UserPreviewDto.FromUser(interlocutor)
            };

            return Ok(dto);
        }
    }
}
