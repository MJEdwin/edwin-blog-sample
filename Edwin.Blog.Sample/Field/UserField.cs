using System;
using System.Collections.Generic;
using System.Text;

namespace Edwin.Blog.Sample
{
    public class UserField
    {
        public static readonly string TokenPrefix;
        static UserField()
        {
            TokenPrefix = "Bearer";
        }
        public UserField()
        {
            id = Guid.NewGuid().ToString("N");
            passwordHash = "123456";
        }

        public readonly string id;

        public string userName;

        private string passwordHash;

        public string GetPasswodHash()
        {
            return passwordHash;
        }

        public void SetPassword(string password)
        {
            passwordHash = password;
        }
    }
}
