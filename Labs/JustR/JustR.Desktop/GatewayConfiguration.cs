using System;

namespace JustR.Desktop
{
    public static class GatewayConfiguration
    {
        // TODO : Вынести в appsettings
        public static String ApiGatewaySource { get; set; } = "http://localhost:5001/api";
    }
}