using System;
using System.IO;
using System.Reflection;
using JustR.Models.Dto;

namespace JustR.Desktop.SampleData
{
    public static class SampleData
    {
        public static readonly String PicturesPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.Parent?.FullName!, "SampleData");
        public static class Sergey
        {
            public static Byte[] Avatar { get; set; } =
                File.ReadAllBytes(Path.Combine(PicturesPath, "Sergey.jpg"));

            public static String Name { get; set; } = "Sergey";

            public static Guid UserId { get; set; } = Guid.Parse("D0CAEA21-05B7-491A-8E80-BD8F5619CA98");
            
            public static String UniqueTag { get; set; } = "@s4xack";

            public static Guid DialogId { get; set; } = Guid.Parse("1855AAC5-C325-444F-ABA4-6AAF7FFCA6D9");

        }
        public static class Katya
        {
            public static Byte[] Avatar { get; set; } =
                File.ReadAllBytes(Path.Combine(PicturesPath, "Katya.jpg"));
            public static String Name { get; set; } = "Katya";
            public static Guid UserId { get; set; } = Guid.Parse("88E90EE1-2F0B-4AF1-8EA5-0DD90F791B0D");

            public static String UniqueTag { get; set; } = "@hatulmadan";

            public static Guid DialogId { get; set; } = Guid.Parse("D73F6869-E4F7-474F-B267-00658F0B5AFA");


        }
        public static class Maksim
        {
            public static Byte[] Avatar { get; set; } = File.ReadAllBytes(Path.Combine(PicturesPath, "Maksim.jpg"));
            public static String Name { get; set; } = "Coomman";
            public static Guid UserId { get; set; } = Guid.Parse("6BA45289-5A34-415B-8187-B72A637C63F2");

            public static String UniqueTag { get; set; } = "@Im2strng4dtwrld";

            public static Guid DialogId { get; set; } = Guid.Parse("14D6485C-DDA9-4C9B-9D3B-6CFB19630290");


        }
        public static class Zeleniy
        {
            public static Byte[] Avatar { get; set; } =
                File.ReadAllBytes(Path.Combine(PicturesPath, "Кисик.jpg"));
            public static String Name { get; set; } = "Zeleniy";
            public static Guid UserId { get; set; } = Guid.Parse("064E8F45-A625-4183-9B42-2A5EA6F45AFA");

            public static Guid DialogId { get; set; } = Guid.Parse("09BB4BBC-CAAB-459A-BDD2-B533E9188FC7");

            public static String UniqueTag { get; set; } = "@Im2strng4dtwrld";

        }
    }
}
