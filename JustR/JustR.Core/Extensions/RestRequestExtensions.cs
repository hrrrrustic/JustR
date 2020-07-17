using System;
using RestSharp;

namespace JustR.Core.Extensions
{
    public static class RestRequestExtensions
    {
        public static IRestRequest AddQueryParameter<T>(this IRestRequest request, String name, T value)
            where T : notnull
        {
            if (value is null)
                //TODO : Сообщение
                throw new ArgumentNullException();

            return request.AddQueryParameter(name, value.ToString());
        }
    }
}