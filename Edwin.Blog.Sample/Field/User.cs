using System;

namespace Edwin.Blog.Sample
{
    public class User
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; private set; }

        public void SetPassword(string password)
        {
            PasswordHash = password;
        }
    }

    public class User2
    {
        public string Id { get; set; }

        private string _userName;
        public string UserName { get => _userName; set => _userName = value; }

        private string _passwordHash;
        public string PasswordHash { get => _passwordHash; private set => _passwordHash = value; }

        public void SetPassword(string password)
        {
            PasswordHash = password;
        }
    }
}
