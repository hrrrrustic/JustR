using System;
using System.IO;
using JustR.Desktop.Annotations;
using JustR.Desktop.SampleData;

namespace JustR.Desktop
{
    public static class UserInfo
    {
        public static readonly SampleData.SampleData.Person CurrentUser = new User();

        private class User : SampleData.SampleData.Person
        {
            public User() : base("Clown.png", "Vlad", "17FD3701-C416-4FE1-BB01-98A5AB9E178C", "@hrrrrustic",
                "A5DA2549-DE49-4A97-A377-19A2DB36E0DC")
            {

            }
        }
    }
}