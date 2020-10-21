using Neo;
using System;
using System.Reflection;

namespace RpcClientTest
{
    class Title
    {
        public void SetColor()
        {
            var neoVersion = Assembly.GetAssembly(typeof(NeoSystem)).GetVersion();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Powered by ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("RpcClient ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("for ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Neo v" + neoVersion);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }
}
