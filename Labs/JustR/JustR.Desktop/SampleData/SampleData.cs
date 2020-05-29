using System;
using System.Collections.Generic;
using System.IO;
using System.Printing.IndexedProperties;
using System.Reflection;
using System.Windows.Documents;
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

        public static List<Person> DefaultPersons = new List<Person>
        {
            Sergey, Katya, Zeleniy, Maksim, Vova, Ilya
        };
        public abstract class Person
        {
            public static readonly String PicturesPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.Parent?.FullName!, "SampleData");
            public Byte[] Avatar { get; set; }
            public String FirstName { get; set; }
            public String LastName { get; set; }
            
            public Guid UserId { get; set; }
            public String UniqueTag { get; set; }
            public Guid DialogId { get; set; }

            protected Person(String pictureName, String name, String userId, String uniqueTag, String dialogId)
            {
                Avatar = File.ReadAllBytes(Path.Combine(PicturesPath, pictureName));
                FirstName = name;
                UserId = Guid.Parse(userId);
                UniqueTag = uniqueTag;
                DialogId = Guid.Parse(dialogId);
            }

            public UserPreviewDto ToUserPreviewDto()
            {
                return new UserPreviewDto
                {
                    Avatar = Avatar,
                    FirstName = FirstName,
                    LastName = LastName,
                    UniqueTag = UniqueTag,
                    UserId = UserId
                };
            }

            public UserProfileDto ToUserProfileDto()
            {
                return new UserProfileDto
                {
                    Avatar = Avatar,
                    FirstName = FirstName,
                    LastName = LastName,
                    UniqueTag = UniqueTag,
                    UserId = UserId,
                };
            }
        }

        private class SergeyPerson : Person
        {
            public SergeyPerson() : base("Sergey.jpg", "Sergey", "7028358D-356B-4F2E-84E5-823B651919C7", "@s4xack",
                "78DC7134-344C-4885-B71E-D132E8C42468")
            {

            }

        }

        private class KatyaPerson : Person
        {
            public KatyaPerson() : base("Katya.jpg", "Katya", "3D30EBC8-5701-4385-96EF-C7C831AA64B2", "@hatulmadan",
                "8C4FDE54-ADBD-4656-B001-24FE46C329CE")
            {

            }
        }

        private class MaksimPerson : Person
        {
            public MaksimPerson() : base("Maksim.jpg", "Maksim", "7884C5EC-A9E2-48DA-B04C-5A03C76FCECC", "@coomman",
                "D7C404B2-0B4D-4FED-A2AB-4399254AB325")
            {

            }
        }

        private class ZeleniyPerson : Person
        {
            public ZeleniyPerson() : base("Кисик.jpg", "Zeleniy", "BB188BF5-F451-4F40-B912-D159F2E658AC", "@Im2strng4dtwrld",
                "0F91DAE2-42F1-4C4B-AD85-0638C6DE1037")
            {

            }
        }

        private class VovaPerson : Person
        {
            public VovaPerson() : base("Vova.jpg", "Vova", "C2412B87-DC6B-4971-B7F6-4ACDFF66C95B", "@DBECTNWECTON",
                "4327B089-3D03-491B-AB89-60E2C9A6B3A6")
            {

            }
        }

        private class IlyaPerson : Person
        {
            public IlyaPerson() : base("Ilya.jpg", "Ilya", "32D98910-7546-4C49-92EE-1B4335F4862F", "@Aroize",
                "3990BDEA-544D-4682-8A93-DFBF7601922D")
            {

            }
        }
    }
}
