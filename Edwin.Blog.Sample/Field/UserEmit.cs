using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;

namespace Edwin.Blog.Sample
{
    public class UserEmit
    {
        public static Type Emit()
        {
            var asmBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("Edwin.Blog.Emit"), AssemblyBuilderAccess.Run);
            var moduleBuilder = asmBuilder.DefineDynamicModule("Edwin.Blog.Emit");
            var typeBuilder = moduleBuilder.DefineType("UserField", TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.BeforeFieldInit);

            //第一个变量表示字段名称，第二个变量表示字段的类型，第三个变量表示字段的特性(修饰符)为public readonly static
            var tokenPrefixBuilder = typeBuilder.DefineField("TokenPrefix", typeof(string), FieldAttributes.Public | FieldAttributes.InitOnly | FieldAttributes.Static);
            var idBuilder = typeBuilder.DefineField("id", typeof(string), FieldAttributes.Public | FieldAttributes.InitOnly);
            var userNameBuilder = typeBuilder.DefineField("userName", typeof(string), FieldAttributes.Public);
            var passwordHashBuilder = typeBuilder.DefineField("passwordHash", typeof(string), FieldAttributes.Private);

            //创建静态构造器(第一个参数表示为私有静态，第三个参数表示入参类型)
            var staticCtorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Private | MethodAttributes.Static | MethodAttributes.SpecialName | MethodAttributes.HideBySig, CallingConventions.Standard, Type.EmptyTypes);
            var staticCtorIL = staticCtorBuilder.GetILGenerator();
            //将常量字符串"Bearer"放入栈顶
            staticCtorIL.Emit(OpCodes.Ldstr, "Bearer");
            //取出栈顶元素赋值给字段
            staticCtorIL.Emit(OpCodes.Stsfld, tokenPrefixBuilder);
            //返回
            staticCtorIL.Emit(OpCodes.Ret);

            var ctorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, CallingConventions.Standard, Type.EmptyTypes);
            var ctorIL = ctorBuilder.GetILGenerator();
            //将this压入栈中
            ctorIL.Emit(OpCodes.Ldarg_0);
            //将常量字符串"123456"放入栈顶
            ctorIL.Emit(OpCodes.Ldstr, "123456");
            //取出栈顶元素赋值给字段
            ctorIL.Emit(OpCodes.Stfld, passwordHashBuilder);
            //返回
            ctorIL.Emit(OpCodes.Ret);

            var getPasswordHashMethodBuilder = typeBuilder.DefineMethod("GetPasswordHash", MethodAttributes.Public | MethodAttributes.HideBySig, CallingConventions.Standard, typeof(string), Type.EmptyTypes);
            var getPasswordHashIL = getPasswordHashMethodBuilder.GetILGenerator();
            //将this压入栈中
            getPasswordHashIL.Emit(OpCodes.Ldarg_0);
            //将字段值压入到栈中
            getPasswordHashIL.Emit(OpCodes.Ldfld, passwordHashBuilder);
            //返回
            getPasswordHashIL.Emit(OpCodes.Ret);

            return typeBuilder.CreateTypeInfo().AsType();
        }
    }
}
