using System;

namespace PlatformInvoke
{
    class Program
    {
        private static ManagedCodeObject _managedCodeObject;

        static void Main(string[] args)
        {
            _managedCodeObject = ManagedCodeObject.Create();

            Console.WriteLine(".NET Core Platform Invoke example");
            Console.WriteLine();
            Console.WriteLine(_managedCodeObject.GetPlatformDescription());
            Console.WriteLine();

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
