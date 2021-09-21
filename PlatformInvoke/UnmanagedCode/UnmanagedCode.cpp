// Unmanaged code for platform invoke example.

// Compile for Linux.
// gcc UnmanagedCode.cpp -shared -o ../bin/Debug/x64/libUnmanagedCode.so -fPIC

// Compile for macOS.
// gcc UnmanagedCode.cpp -shared -o ../bin/Debug/x64/libUnmanagedCode.dylib -fPIC

// Help definitions.
#include "Dependency.h"

// Container with platform description.
const int DESCRIPTION_SIZE = 256;
char _platformDescription[DESCRIPTION_SIZE];

// Returns current platform description.
#ifdef PROC_OS_WIN
#pragma warning(disable : 4996)

const char *GetPlatformDescription()
{
	OSVERSIONINFOEX info;
	ZeroMemory(&info, sizeof(OSVERSIONINFOEX));
	info.dwOSVersionInfoSize = sizeof(OSVERSIONINFOEX);
	GetVersionExW((LPOSVERSIONINFO)&info);
	sprintf_s(_platformDescription, DESCRIPTION_SIZE, "Unmanaged %llu-bit code for Windows %lu.%lu\n\0", sizeof(int*) * 8, info.dwMajorVersion, info.dwMinorVersion);
	return _platformDescription;
}

#elif defined(PROC_OS_LINUX)

extern "C"
{

__attribute__ ((visibility ("default"))) const char *GetPlatformDescription()
{
	struct utsname info;
	uname(&info);
	sprintf(_platformDescription, "Unmanaged %u-bit code for %s %s\n\0", sizeof(int*) * 8, info.sysname, info.release);
	return _platformDescription;
}

}

#elif defined(PROC_OS_DARWIN)

extern "C"
{

__attribute__ ((visibility ("default"))) const char *GetPlatformDescription()
{
	sprintf(_platformDescription, "Unmanaged %u-bit code for macOS :)\n\0");
	return _platformDescription;
}

}

#else
#error "Example has not been ported to this platform."
#endif

int main(int argc, char* argv[])
{
	return 0;
}
