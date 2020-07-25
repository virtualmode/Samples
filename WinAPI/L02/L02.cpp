
#include <stdio.h>
#include <windows.h>

#define TEXT_SIZE 128

int i; // Переменная для цикла.
char Text[3][TEXT_SIZE]; // Буфер для текста. 0 - Загруженность памяти и т.д.
HDC hDC; // Указатель на контекст для рисования.
SYSTEM_INFO System; // Системная информация.
MEMORYSTATUS Memory; // Информация о состоянии памяти.

// Функция обработки сообщений ОС Windows:
LRESULT CALLBACK MainWinProc(HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	switch (Message)
	{
		case WM_PAINT:
			for (i = 0; i < 3; i++) TextOutA(hDC, 30, 50 + i * 25, Text[i], (int)strlen(Text[i])); // Вывод текста на экран.
			break;

		case WM_DESTROY:
			PostQuitMessage(0);
			return 0;

		default:
			break;
	}
	return DefWindowProc(hWnd, Message, wParam, lParam);
}

// Точка входа в приложение:
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	// Определение необходимых переменных:
	WNDCLASSEX WindowClassEx; // Структура для хранения информации о создаваемом окне.
	HWND hWndMain; // Идентификатор основного окна.
	MSG Message; // Переменная для обработки сообщений.
	
	// Заполнение структуры WindowClassEx:
	WindowClassEx.cbSize = sizeof(WNDCLASSEX);
	WindowClassEx.style = CS_DBLCLKS | CS_OWNDC | CS_HREDRAW | CS_VREDRAW; // Не напрягайтесь, это просто флаги. К лабораторной не имеют никакого отношения.
	WindowClassEx.lpfnWndProc = MainWinProc; // Указатель на функцию обработки сообщений ОС Windows.
	WindowClassEx.cbClsExtra = 0;
	WindowClassEx.cbWndExtra = 0;
	WindowClassEx.hInstance = hInstance;
	WindowClassEx.hIcon = NULL; // Иконка отсутствует.
	WindowClassEx.hCursor = LoadCursor(0, IDC_ARROW);
	WindowClassEx.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH); // Белый цвет окна.
	WindowClassEx.lpszMenuName = 0; // Меню отсутствует.
	WindowClassEx.lpszClassName = L"Laboratory"; // Имя класса. Используется операционной системой.
	WindowClassEx.hIconSm = LoadIcon(0, MAKEINTRESOURCE(32517)); // Какая-то иконка по умолчанию.

	RegisterClassEx(&WindowClassEx); // Регистрация класса окна, информация о котором берется из вышеописанной структуры.

	// Создание основного окна:
	hWndMain = CreateWindowEx(0, L"Laboratory", L"Лабораторная работа 2", WS_TILEDWINDOW, 50, 50, 640, 480, 0, 0, hInstance, 0);

	// Получение разнообразной информации:
	GetSystemInfo(&System);
	GlobalMemoryStatus(&Memory);
	
	// Создание текста, на основе полученной информации, для вывода на экран:
	sprintf_s(Text[0], TEXT_SIZE, "Всего физической памяти: %i Мб.\0", Memory.dwTotalPhys / 1048576);
	sprintf_s(Text[1], TEXT_SIZE, "Загружено памяти: %i%%.\0", Memory.dwMemoryLoad);
	sprintf_s(Text[2], TEXT_SIZE, "Количество процессоров: %i.\0", System.dwNumberOfProcessors);
	

	// Отображение всего созданного на экране:
	ShowWindow(hWndMain, SW_SHOWDEFAULT);
	UpdateWindow(hWndMain);

	// Получение контекста для рисования в окне:
	hDC = GetWindowDC(hWndMain);
	SendMessage(hWndMain, WM_PAINT, 0, 0);

	// Запуск основного цикла обработки сообщений:
	while (GetMessage(&Message, 0, 0, 0))
	{
		TranslateMessage(&Message);
		DispatchMessage(&Message);
	}

	// Если из цикла вышли, значит пользователь (а может и не он вовсе) закрыл приложение:
	return (int) Message.wParam;
}
