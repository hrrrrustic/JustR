using System;

namespace JustR.DesktopGateway
{
    //TODO : Вынести хотя бы в appsettings
    public static class ServiceConfigurations
    {
        public static String ProfileServiceUri { get; set; } = "http://localhost:5005/api/Profile";
        public static String DialogServiceUri { get; set; } = "http://localhost:5006/api/Dialog";
        public static String MessageServiceUri { get; set; } = "http://localhost:5007/api/Message";
        public static String FriendServiceUri { get; set; } = "http://localhost:5002/api/Friend";
    }
}       