using Edwin.Blog.Sample;
using System;

namespace Edwin.Blog.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = UserEmit.Emit();
            dynamic user = Activator.CreateInstance(type);
            Console.WriteLine(user.GetPasswordHash());
        }
    }
}
