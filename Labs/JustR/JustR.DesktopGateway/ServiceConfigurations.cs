﻿using System;

namespace JustR.DesktopGateway
{
    public static class ServiceConfigurations
    {
        public static String ProfileServiceUri { get; set; } = "http://localhost:5005/api/Profile";
        public static String DialogServiceUri { get; set; }
        public static String MessageServiceUri { get; set; }
        public static String FriendServiceUri { get; set; }
    }
}       