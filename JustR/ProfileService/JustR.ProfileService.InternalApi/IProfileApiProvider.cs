using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Core.Entity;

namespace JustR.ProfileService.InternalApi
{
    // TODO : Подцепить эти интерфейсы на контроллеры как-нибудь. (сейчас мешаются ActionResult<T>'ы)
    public interface IProfileApiProvider
    {
        Task<User> GetUserProfile(Guid userId);
        Task<User> GetUserPreview(Guid userId);
        Task<IReadOnlyList<User>> GetUsersPreview(IEnumerable<Guid> usersId);
        Task<IReadOnlyList<User>> SearchUser(String query);
        Task<User> UpdateUserProfile(User user);

        // TODO : Выпилить после реализации аутент. и автор.
        Task<User> SimpleLogIn(String userTag);
    }
}