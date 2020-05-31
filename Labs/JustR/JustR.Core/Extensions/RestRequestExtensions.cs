using System;
using RestSharp;

namespace JustR.Core.Extensions
{
    public static class RestRequestExtensions
    {
        public static IRestRequest AddQueryParameter<T>(this IRestRequest request, String name, T value)
        {
            if (value is null)
                return request;

            return request.AddQueryParameter(name, value.ToString());
        }
    }
}