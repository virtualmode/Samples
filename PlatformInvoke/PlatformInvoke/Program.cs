// Platform invoke example with path probing to support different architectures in different dll's.
// NativeLibrary, DllImportResolver, AssemblyLoadContext looks like possible right solutions.

// Path probing.
// https://docs.microsoft.com/en-us/dotnet/core/dependency-loading/default-probing
// https://dev.to/jeikabu/loading-native-libraries-in-c-fh6

// Deep-dive into .NET Core primitives: deps.json, runtimeconfig.json, and dll's.
// https://natemcmaster.com/blog/2017/12/21/netcore-primitives/

// How to load library safely.
// https://msrc-blog.microsoft.com/2014/05/13/load-library-safely/

using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace PlatformInvoke
{
    class Program
    {
        private static ManagedCodeObject _managedCodeObject;

        static void Main(string[] args)
        {
            // Register the import resolver before calling the imported function.
            // Only one import resolver can be set for a given assembly.
            NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), DllImportResolver);

            _managedCodeObject = ManagedCodeObject.Create();

            Console.WriteLine(".NET Core Platform Invoke example");
            Console.WriteLine(_managedCodeObject.GetPlatformDescription());
        }

        /// <summary>
        /// Custom dynamic link library resolver.
        /// </summary>
        /// <param name="libraryName">It's very important to use only name without path and extension.</param>
        /// <param name="assembly">The assembly for which the resolver is registered.</param>
        /// <param name="searchPath">Specifies the paths that are used to search.</param>
        /// <returns></returns>
        private static IntPtr DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            if (NativeLibrary.TryLoad((Environment.Is64BitProcess ? "x64/" : "x86/") + libraryName,
                assembly,
                searchPath,
                out IntPtr result))
                return result;

            //// MSDN example with AVX2 instructions.
            //if (libraryName == "nativedep")
            //{
            //    // On systems with AVX2 support, load a different library.
            //    if (System.Runtime.Intrinsics.X86.Avx2.IsSupported)
            //        return NativeLibrary.Load("nativedep_avx2", assembly, searchPath);
            //}

            // Otherwise, fallback to default import resolver.
            return IntPtr.Zero;
        }
    }
}
