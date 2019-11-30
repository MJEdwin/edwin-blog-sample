using Edwin.Blog.Sample;
using Edwin.Blog.Sample.Property;
using System;

namespace Edwin.Blog.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = BlogEmit.Emit();
            dynamic user = Activator.CreateInstance(type);
            user.Title = "Emit高级特性-属性";
            user.Content = "xxx";
            Console.WriteLine(user.Title);
        }
    }
}
