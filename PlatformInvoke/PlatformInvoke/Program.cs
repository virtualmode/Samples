// Platform invoke example with path probing to support different architectures in different dll's.
// NativeLibrary with RID's in runtimeTargets property, DllImportResolver, AssemblyLoadContext looks like possible right solutions.

// NativeLibrary introduction.
// https://developers.redhat.com/blog/2019/09/06/interacting-with-native-libraries-in-net-core-3-0#dllimport
// https://docs.microsoft.com/en-us/dotnet/core/rid-catalog
// https://docs.microsoft.com/en-us/dotnet/standard/native-interop/cross-platform

// Path probing.
// https://docs.microsoft.com/en-us/dotnet/core/dependency-loading/default-probing
// https://dev.to/jeikabu/loading-native-libraries-in-c-fh6

// Deep-dive into .NET Core primitives: deps.json, runtimeconfig.json, and dll's.
// https://natemcmaster.com/blog/2017/12/21/netcore-primitives/
// https://github.com/stuartleeks/dotnet-cli/blob/master/Documentation/specs/runtime-configuration-file.md

// How to load library safely.
// https://msrc-blog.microsoft.com/2014/05/13/load-library-safely/

// .NET in Linux video.
// https://www.youtube.com/watch?v=Rudg4FlD3Vs

// Configuration of .NET Core for AMD64.
// MSIL can work on any platform, but native libraries depends on configuration:
// "Any CPU" equals to current processor architecture and can invoke only x64 native code.
// "Any CPU with Prefer 32-bit" runs as a 32-bit application.
// "x86" runs as a WoW64 application.
// "x64" runs as a 64-bit application.

// Project RID's <RuntimeIdentifiers>win10-x86;win10-x64</RuntimeIdentifiers> prompts only to download appropriate packages.

using System.Reflection;
using System.Runtime.InteropServices;

using PInvokePackage;

/// <summary>
/// Custom dynamic link library resolver example.
/// </summary>
/// <param name="libraryName">It's very important to use only name without path and extension.</param>
/// <param name="assembly">The assembly for which the resolver is registered.</param>
/// <param name="searchPath">Specifies the paths that are used to search.</param>
/// <returns>Dll handler.</returns>
IntPtr DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
{
    //string library = $"{Environment.CurrentDirectory}/{(Environment.Is64BitProcess ? "x64" : "x86")}/lib{libraryName}.so";
    //string library = $"{(Environment.Is64BitProcess ? "x64" : "x86")}/{libraryName}";

    if (NativeLibrary.TryLoad(libraryName,
        assembly,
        null, // Search without path modifiers in custom resolver.
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

// Register the import resolver before calling the imported function.
// Only one import resolver can be set for a given assembly (or typeof(MyClass).Assembly).
//NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), DllImportResolver);

var _managedCodeObject = ManagedCodeObject.Create();

Console.WriteLine(".NET Core Platform Invoke example");
Console.WriteLine(_managedCodeObject.GetPlatformDescription());

return 0;
