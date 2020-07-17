using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.Desktop.Services.Abstractions;
using JustR.DesktopGateway.PublicApi;

namespace JustR.Desktop.Services.Implementations
{
    public class DialogService : IDialogService
    {
        private readonly IDesktopGatewayApiProvider _desktopGatewayApiProvider =
            new HttpDesktopGatewayApiProvider(GatewayConfiguration.ApiGatewaySource);

        public async Task<IReadOnlyList<DialogPreviewDto>> GetDialogsPreviewAsync(Guid userId)
        {
            // TODO : Убрать хардкор оффсета
            return await _desktopGatewayApiProvider.DialogEntityApiProvider.GetDialogs(userId, 0, 100);
        }

        public async Task<DialogInfoDto> GetDialogInfoAsync(Guid dialogId, Guid userId)
        {
            return await _desktopGatewayApiProvider.DialogEntityApiProvider.GetDialog(dialogId, userId);
        }

        public async Task<Guid> GetDialogIdAsync(Guid firstUserId, Guid secondUserId)
        {
            return await _desktopGatewayApiProvider.DialogEntityApiProvider.GetDialogId(firstUserId, secondUserId);
        }

        public async Task<DialogInfoDto> CreateDialogAsync(DialogPreviewDto newDialog)
        {
            return await _desktopGatewayApiProvider.DialogEntityApiProvider.CreateDialog(UserInfo.CurrentUser.UserId,
                newDialog.InterlocutorPreview.UserId);
        }
    }
}