// Управляемый код пакета фактически должен представлять набор реализаций PInvoke-классов,
// задача которых состоит в предоставлении доступа к структурам и экспортированным функциям библиотек
// через слой автоматического подключения необходимых реализаций.
namespace NetSdkPack
{
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Временный класс, используемый для перевода разработки с .NET Framework на современную .NET платформу.
    /// Предназначен для переопределения старого механизма подключения динамических библиотек без необходимости вносить лишние изменения.
    /// Данный класс может быть удалён, когда исполняемый код будет собран на .NET актуальной версии.
    /// Необходимо отметить, что .NET Framework сборки не являются кросс-платформенными, поэтому учитывается только одна операционная система.
    /// </summary>
    [Obsolete("Use only to support .NET Framework compilation.")]
    internal sealed class LegacyPInvoke
    {
        #region Constants

        /// <summary>
        /// Общий идентификатор
        /// </summary>
        private const string SHARED_PRIMITIVE_NAME = "NetSdkPackLegacyPInvoke";

        /// <summary>
        /// Параметр для поиска динамических библиотек.
        /// - корневой каталог приложения
        /// - выбранные через AddDllDirectory или SetDllDirectory
        /// - %windows%\system32
        /// </summary>
        private const uint LOAD_LIBRARY_SEARCH_DEFAULT_DIRS = 0x00001000;

        /// <summary>
        /// Стандартный каталог .NET для Windows x86 неуправляемых сборок.
        /// </summary>
        private const string RUNTIMES_WIN_X86_NATIVE_PATH = "\\runtimes\\win-x86\\native";

        /// <summary>
        /// Стандартный каталог .NET для Windows x64 неуправляемых сборок.
        /// </summary>
        private const string RUNTIMES_WIN_X64_NATIVE_PATH = "\\runtimes\\win-x64\\native";

        /// <summary>
        /// Устаревший каталог для x86 неуправляемых сборок.
        /// </summary>
        private const string LEGACY_X86_PATH = "\\x86";

        /// <summary>
        /// Устаревший каталог для x64 неуправляемых сборок.
        /// </summary>
        private const string LEGACY_X64_PATH = "\\x64";

        #endregion Constants

        #region Delegates

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetDefaultDllDirectories(uint directoryFlags);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int AddDllDirectory(string newDirectory);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool RemoveDllDirectory(int cookie);

        #endregion Delegates

        #region Fields

        private static readonly LegacyPInvoke _instance = new LegacyPInvoke();

        public readonly bool Initialized;

        #endregion Fields

        #region Constructors

        static LegacyPInvoke()
        {
#if NETFRAMEWORK
            // Код с переопределением подключения динамических библиотек допустимо копировать и запускать из любого места.
            // Чтобы не добавлять каталоги по несколько раз из разных сборок внутри одного процесса необходима дополнительная проверка.
            string sharedPrimitiveId = SHARED_PRIMITIVE_NAME + System.Diagnostics.Process.GetCurrentProcess().Id;
            if (!System.Threading.Mutex.TryOpenExisting(sharedPrimitiveId, out var result))
            {
                result = new System.Threading.Mutex(false, sharedPrimitiveId);

                // Установка флагов для поиска динамических библиотек.
                SetDefaultDllDirectories(LOAD_LIBRARY_SEARCH_DEFAULT_DIRS);

                // Добавление стандартных .NET каталогов.
                AddDllDirectory(AppContext.BaseDirectory + RUNTIMES_WIN_X86_NATIVE_PATH);
                AddDllDirectory(AppContext.BaseDirectory + RUNTIMES_WIN_X64_NATIVE_PATH);

                // Добавление устаревших каталогов.
                AddDllDirectory(AppContext.BaseDirectory + LEGACY_X86_PATH);
                AddDllDirectory(AppContext.BaseDirectory + LEGACY_X64_PATH);
            }
#else
            // Register the import resolver before calling the imported function.
            // Only one import resolver can be set for a given assembly (or typeof(MyClass).Assembly).
            //NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), DllImportResolver);
#endif
        }

        private LegacyPInvoke()
        {
            Initialized = true;
        }

        #endregion Constructors

        #region Methods

        public static LegacyPInvoke Initialize() => _instance;

#if NET
        /// <summary>
        /// Пример переопределения нового механизма подключения динамических библиотек.
        /// </summary>
        /// <param name="libraryName">Имя библиотеки должно быть без пути и расширения.</param>
        /// <param name="assembly">Сборка, для которой производится переопределение.</param>
        /// <param name="searchPath">Флаги поиска путей.</param>
        /// <returns>Указатель на загруженную сборку.</returns>
        [Obsolete("This is only an example.")]
        private static IntPtr DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            //string library = $"{Environment.CurrentDirectory}/{(Environment.Is64BitProcess ? "x64" : "x86")}/lib{libraryName}.so";
            string library = $"{(Environment.Is64BitProcess ? "x64" : "x86")}{libraryName}";

            if (NativeLibrary.TryLoad(library,
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
#endif

        #endregion Methods
    }
}
