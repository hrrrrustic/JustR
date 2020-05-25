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
using Microsoft.Extensions.WebEncoders.Testing;
using Newtonsoft.Json;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace JustR.DesktopGateway.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DialogController : Controller
    {
        private readonly HttpClient _dialogClient;
        private readonly HttpClient _profileClient;

        public DialogController()
        {
            _dialogClient = new HttpClient();
            _dialogClient.BaseAddress = new Uri(ServiceConfigurations.DialogServiceUri);

            _profileClient = new HttpClient();
            _profileClient.BaseAddress = new Uri(ServiceConfigurations.ProfileServiceUri);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DialogPreviewDto>>> GetDialogs(Guid userId, Int32? offset, Int32 count)
        {
            Dictionary<String, String> queryParams = new Dictionary<String, String>();
            queryParams.Add(nameof(userId), userId.ToString());

            if(!(offset is null))
                queryParams.Add(nameof(offset), offset.Value.ToString());

            queryParams.Add(nameof(count), count.ToString());

            var response = await _dialogClient.GetAsync(new QueryBuilder(queryParams).ToQueryString().Value);

            var stringResult = await response.Content.ReadAsStringAsync();

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dialog>>(stringResult);

            DialogPreviewDto dto = new DialogPreviewDto();
            List<DialogPreviewDto> previews = new List<DialogPreviewDto>(result.Count);
            foreach (Dialog dialog in result)
            {
                Guid id = dialog.FirstUserId;

                if (dialog.FirstUserId == userId)
                    id = dialog.SecondUserid;

                User currentUser = await Test(id);

                var preview = new DialogPreviewDto
                {
                    DialogName = dialog.DialogName,
                    DialogId = dialog.DialogId,
                    LastMessageText = dialog.LastMessageText,
                    LastMessageTime = dialog.LastMessageTime,
                    InterlocutorPreview = new UserPreviewDto
                    {
                        Avatar = currentUser.Avatar,
                        UniqueTag = currentUser.UniqueTag,
                        UserId = currentUser.UserId,
                        UserName = currentUser.FirstName + " " + currentUser.LastName
                    }
                };

                previews.Add(preview);
            }

            return Ok(previews);

            async Task<User> Test(Guid id)
            {
                Dictionary<String, String> queryParams = new Dictionary<String, String>();
                queryParams.Add("userId", id.ToString());
                var query = new QueryBuilder(queryParams);
                var secondResponse = await _profileClient.GetAsync("preview" + query.ToQueryString().Value);
                var res = await secondResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(res);
            }
        }

        [HttpGet("{dialogId}")]
        public ActionResult<DialogInfoDto> GetDialog(Guid userId, Guid dialogId)
        {
            throw new NotImplementedException();
        }
    }
}
