using System;
using System.IO;

namespace JustR.Desktop
{
    public static class UserInfo
    {
        public static Guid UserId { get; set; } = Guid.Parse("17FD3701-C416-4FE1-BB01-98A5AB9E178C");
        public static Byte[] Avatar { get; set; } = File.ReadAllBytes(Path.Combine(SampleData.SampleData.PicturesPath, "Kappa.png"));
        public static String UniqueTag { get; set; } = "@hrrrrustic";
        public static String UserName { get; set; } = "Vlad";
    }
}