using System;

namespace JustR.Desktop.Model
{
    public class AuthenticationModel
    {
        public String Login { get; set; }
        public String Password { get; set; }

        public Boolean Authenticate(out Guid id)
        {
            if (Login == Password)
            {
                id = Guid.NewGuid();
                return true;
            }

            id = Guid.Empty;

            return false;
        }
    }
}