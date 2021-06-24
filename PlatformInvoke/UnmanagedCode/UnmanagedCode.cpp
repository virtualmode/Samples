// Unmanaged code for platform invoke example.

// Help definitions.
#include "Dependency.h"

// Container with platform description.
const int DESCRIPTION_SIZE = 256;
char _platformDescription[DESCRIPTION_SIZE];

// Returns current platform description.
const char *GetPlatformDescription()
{
#ifdef PROC_OS_WIN
#pragma warning(disable : 4996)

	OSVERSIONINFOEX info;
	ZeroMemory(&info, sizeof(OSVERSIONINFOEX));
	info.dwOSVersionInfoSize = sizeof(OSVERSIONINFOEX);
	GetVersionExW((LPOSVERSIONINFO)&info);
	sprintf_s(_platformDescription, DESCRIPTION_SIZE, "Unmanaged %u-bit code for Windows %u.%u\n\0", sizeof(int*) * 8, info.dwMajorVersion, info.dwMinorVersion);

#elif defined(PROC_OS_LINUX)

	sprintf_s(_platformDescription, DESCRIPTION_SIZE, "Unmanaged %u-bit code for Linux %u.%u\n\0", sizeof(int*) * 8, 1, 0);

#elif defined(PROC_OS_DARWIN)

	sprintf_s(_platformDescription, DESCRIPTION_SIZE, "Unmanaged %u-bit code for macOS %u.%u\n\0", sizeof(int*) * 8, 1, 0);

#else
#error "Example has not been ported to this platform."
#endif

	return _platformDescription;
}

int main(int argc, char* argv[])
{
	return 0;
}
