using System;
using System.IO;
using System.Printing.IndexedProperties;
using System.Reflection;
using JustR.Models.Dto;

namespace JustR.Desktop.SampleData
{
    public static class SampleData
    {
        public static Person Sergey => new SergeyPerson();
        public static Person Katya => new KatyaPerson();
        public static Person Zeleniy => new ZeleniyPerson();
        public static Person Maksim => new MaksimPerson();
        public static Person Vova => new VovaPerson();
        public static Person Ilya => new IlyaPerson();

        public abstract class Person
        {
            public static readonly String PicturesPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.Parent?.FullName!, "SampleData");
            public Byte[] Avatar { get; set; }
            public String Name { get; set; }
            public Guid UserId { get; set; }
            public String UniqueTag { get; set; }
            public Guid DialogId { get; set; }

            protected Person(String pictureName, String name, String userId, String uniqueTag, String dialogId)
            {
                Avatar = File.ReadAllBytes(Path.Combine(PicturesPath, pictureName));
                Name = name;
                UserId = Guid.Parse(userId);
                UniqueTag = uniqueTag;
                DialogId = Guid.Parse(dialogId);
            }

            public UserPreviewDto ToUserPreviewDto()
            {
                return new UserPreviewDto
                {
                    Avatar = Avatar,
                    UserName = Name,
                    UniqueTag = UniqueTag,
                    UserId = UserId
                };
            }
        }
        public class SergeyPerson : Person
        {
            public SergeyPerson() : base("Sergey.jpg", "Sergey", "D0CAEA21-05B7-491A-8E80-BD8F5619CA98", "@s4xack",
                "1855AAC5-C325-444F-ABA4-6AAF7FFCA6D9")
            {

            }

        }
        public class KatyaPerson : Person
        {
            public KatyaPerson() : base("Katya.jpg", "Katya", "88E90EE1-2F0B-4AF1-8EA5-0DD90F791B0D", "@hatulmadan",
                "D73F6869-E4F7-474F-B267-00658F0B5AFA")
            {

            }
        }
        public class MaksimPerson : Person
        {
            public MaksimPerson() : base("Maksim.jpg", "Maksim", "6BA45289-5A34-415B-8187-B72A637C63F2", "@coomman",
                "14D6485C-DDA9-4C9B-9D3B-6CFB19630290")
            {

            }
        }
        public class ZeleniyPerson : Person
        {
            public ZeleniyPerson() : base("Кисик.jpg", "Zeleniy", "064E8F45-A625-4183-9B42-2A5EA6F45AFA", "@Im2strng4dtwrld",
                "09BB4BBC-CAAB-459A-BDD2-B533E9188FC7")
            {

            }
        }

        public class VovaPerson : Person
        {
            public VovaPerson() : base("Vova.jpg", "Vova", "D3168C22-AB9C-49D0-904E-A613638E7EFE", "@DBECTNWECTON",
                "B464DB99-E3B8-432C-9C31-44983325E412")
            {

            }
        }

        public class IlyaPerson : Person
        {
            public IlyaPerson() : base("Ilya.jpg", "Ilya", "11A0FB3F-57CC-41BF-A4FA-336D26F4118C", "@Aroize",
                "E8C73FC4-3C67-41A1-985F-49C1F20FDCD7")
            {

            }
        }
    }
}
