using JustR.Core.Entity;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using JustR.Core.Extensions;
using Microsoft.AspNetCore.WebUtilities;

namespace JustR.ProfileService.InternalApi
{
    public class HttpProfileApiProvider : IProfileApiProvider
    {
        private readonly HttpClient _client;

        public HttpProfileApiProvider(HttpClient client)
        {
            _client = client;
        }
        public async Task<User> GetUserProfile(Guid userId)
        {
            String query = QueryHelpers.AddQueryString(ProfileServiceHttpEndpoints.GetUserProfile, "userId", userId.ToString());

            var response = await _client.GetAsync(query);

            User user = await response.Content.ReadAsAsync<User>();

            return user;
        }

        public async Task<User> GetUserPreview(Guid userId)
        {
            String query = QueryHelpers.AddQueryString(ProfileServiceHttpEndpoints.GetUserPreview, "userId", userId.ToString());

            var response = await _client.GetAsync(query);

            User userPreview = await response.Content.ReadAsAsync<User>();

            return userPreview;
        }

        public async Task<IReadOnlyList<User>> GetUsersPreview(IEnumerable<Guid> usersId)
        {
            String query = ProfileServiceHttpEndpoints.GetUsersPreview;

            foreach (Guid guid in usersId)
                query = QueryHelpers.AddQueryString(query, "usersId", guid.ToString());

            var response = await _client.GetAsync(query);

            IReadOnlyList<User> users = await response.Content.ReadAsAsync<List<User>>();

            return users;
        }

        public async Task<IReadOnlyList<User>> SearchUser(String searchQuery)
        {
            String query = QueryHelpers.AddQueryString(ProfileServiceHttpEndpoints.SearchUser, "query", searchQuery);
            
            var response = await _client.GetAsync(query);

            List<User> users = await response.Content.ReadAsAsync<List<User>>();

            return users;
        }

        public async Task<User> UpdateUserProfile(User user)
        {
            var response = await _client.PutAsJsonAsync(ProfileServiceHttpEndpoints.UpdateUserProfile, user);

            User updatedProfile = await response.Content.ReadAsAsync<User>();

            return updatedProfile;
        }

        public async Task<User> SimpleLogIn(String userTag)
        {
            String query = QueryHelpers.AddQueryString(ProfileServiceHttpEndpoints.SimpleLogin, "userTag", userTag);

            var response = await _client.GetAsync(query);

            User user = await response.Content.ReadAsAsync<User>();

            return user;
        }
    }
}
