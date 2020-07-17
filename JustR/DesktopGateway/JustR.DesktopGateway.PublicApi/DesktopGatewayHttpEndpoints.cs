using System;

namespace JustR.DesktopGateway.PublicApi
{
    public static class DesktopGatewayHttpEndpoints
    {
        public static class ProfileEndpoints
        {
            public const String ControllerEndpoint = "Profile";
            public const String GetUserProfile = "";
            public const String SearchUser = "search";
            public const String GetUserPreview = "preview";
            public const String SimpleAuth = "login";
            public const String UpdateUserProfile = "";
        }

        public static class MessageEndpoints
        {
            public const String ControllerEndpoint = "Message";
            public const String GetMessages = "";
            public const String SendMessage = "";
        }

        public static class DialogEndpoints
        {
            public const String ControllerEndpoint = "Dialog";
            public const String GetDialogId = "id";
            public const String GetDialogs = "all";
            public const String GetDialog = "";
            public const String CreateDialog = "";
        }

        public static class FriendEndpoints
        {
            public const String ControllerEndpoint = "Friend";
            public const String GetUserFriends = "";
            public const String CreateFriendRequest = "";
            public const String CreateFriendResponse = "";
            public const String DeleteFriend = "";
        }
    }
}