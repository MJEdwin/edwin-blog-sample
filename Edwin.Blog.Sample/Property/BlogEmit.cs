using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace Edwin.Blog.Sample.Property
{
    public class BlogEmit
    {
        public static Type Emit()
        {
            var asmBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("Edwin.Blog.Emit"), AssemblyBuilderAccess.Run);
            var moduleBuilder = asmBuilder.DefineDynamicModule("Edwin.Blog.Emit");
            var typeBuilder = moduleBuilder.DefineType("Blog", TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.BeforeFieldInit);

            typeBuilder.DefineAutomaticProperty("Title", typeof(string));
            typeBuilder.DefineAutomaticProperty("Content", typeof(string));

            return typeBuilder.CreateTypeInfo().AsType();
        }
    }
}
