
#include <windows.h>
#include <stdio.h>

#define TEXT_SIZE 256
#define RECORDS 3

HDC hDC; // Указатель на контекст для рисования.
HWND hWndControl[5];
HINSTANCE Instance;
LRESULT Result;
WNDPROC DefTextProc; // Указатель на функцию обработки текстового поля.
wchar_t Text[RECORDS][TEXT_SIZE];
BOOL UseInherit = 0;

STARTUPINFO si;
PROCESS_INFORMATION pi;

DWORD GetFlagsFromString(LPWSTR String)
{
	DWORD Result = 0;
	int i = 0, f = 0;
	while (String[i] != 0)
	{
		if (String[i] == L',')
		{
			String[i] = 0;
			Result |= _wtoi(String + f);
			f = i + 1;
		}
		i++;
	}
	if (String[i] == 0) Result |= _wtoi(String + f);
	wchar_t Tex[120];
	swprintf_s(Tex, 120, L"Флаги: %i", Result);
	MessageBox(0, Tex, L"", 0);
	return Result;
}

// Обработка сообщений текстового поля:
LRESULT CALLBACK TextProc(HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	Result = DefTextProc(hWnd, Message, wParam, lParam);
	switch (Message)
	{
		case WM_GETTEXT:
			if (Text[0] == 0 || !CreateProcessW(Text[0], Text[1], 0, 0, UseInherit, GetFlagsFromString(Text[2]), 0, 0, &si, &pi))
			{
				MessageBox(0, L"Не удалось запустить дополнительный процесс.", L"", 0);
			}
			break;

		default:
			break;
	}
	return Result;
}

// Функция обработки сообщений ОС Windows:
LRESULT CALLBACK MainWinProc(HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	switch (Message)
	{
		case WM_CREATE: // Инициализация основного окна и создание на нем элементов управления:
			hWndControl[0] = CreateWindowW(L"EDIT", // Название предустановленного класса.
									 L"C:\\WINDOWS\\NOTEPAD.EXE", // Нет заголовка.
									 WS_CHILD | WS_BORDER | WS_VISIBLE | ES_LEFT, // Стиль текстового поля.
									 30, 55, 450, 26, // Размеры текстового поля будут менятся при обработке сообщения WM_SIZE. 
									 hWnd, // Идентификатор родительского окна.
									 (HMENU)0, // Идентификатор элемента.
									 Instance, // Получение идентификатора приложения.
									 0); // Неиспользуемый указатель.
			hWndControl[1] = CreateWindowW(L"BUTTON", L"Запустить", BS_PUSHBUTTON | WS_VISIBLE | WS_CHILD, 490, 55, 177, 25, hWnd, (HMENU)1, Instance, 0);
			hWndControl[2] = CreateWindowW(L"EDIT", 0, WS_CHILD | WS_BORDER | WS_VISIBLE | ES_LEFT, 165, 85, 315, 26, hWnd, (HMENU)2, Instance, 0); // Неиспользуемый указатель.
			hWndControl[3] = CreateWindowW(L"BUTTON", L"Использовать наследование идентификатора.", WS_CHILD | WS_VISIBLE | BS_AUTOCHECKBOX, 30, 115, 450, 26, hWnd, (HMENU)3, Instance, 0);
			hWndControl[4] = CreateWindowW(L"EDIT", 0, WS_CHILD | WS_BORDER | WS_VISIBLE | ES_LEFT, 165, 150, 315, 26, hWnd, (HMENU)4, Instance, 0);
			DefTextProc = (WNDPROC)GetWindowLong(hWndControl[0], GWL_WNDPROC);
			SetWindowLong(hWndControl[0], GWL_WNDPROC, (LONG)TextProc);
			break;

		case WM_COMMAND:
			switch (LOWORD(wParam))
			{
				case 1:
					SendMessage(hWndControl[4], WM_GETTEXT, TEXT_SIZE, (LPARAM)Text[2]);
					SendMessage(hWndControl[2], WM_GETTEXT, TEXT_SIZE, (LPARAM)Text[1]);
					SendMessage(hWndControl[0], WM_GETTEXT, TEXT_SIZE, (LPARAM)Text[0]);
					break;

				case 3:
					if (UseInherit == 0) UseInherit = 1; else UseInherit = 0;
					break;

				default:
					break;
			}
			break;

		case WM_PAINT:
			TextOutW(hDC, 35, 50, L"Введите путь к файлу:", 21); // Вывод текста на экран.
			TextOutW(hDC, 35, 120, L"Командная строка:", 17);
			TextOutW(hDC, 35, 185, L"Флаги (через ','):", 18);
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
	
	Instance = hInstance; // Сохранение идентификатора приложения.

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
	hWndMain = CreateWindowEx(0, L"Laboratory", L"Лабораторная работа 12", WS_TILEDWINDOW, 50, 50, 710, 300, 0, 0, hInstance, 0);

	// Отображение всего созданного на экране:
	ShowWindow(hWndMain, SW_SHOWDEFAULT);
	UpdateWindow(hWndMain);

	// Получение контекста для рисования в окне:
	hDC = GetWindowDC(hWndMain);
	SendMessage(hWndMain, WM_PAINT, 0, 0);

	ZeroMemory( &si, sizeof(si) );
	si.cb = sizeof(si);
	ZeroMemory( &pi, sizeof(pi) );

	// Wait until child process exits.
	//WaitForSingleObject(pi.hProcess, INFINITE);

	// Запуск основного цикла обработки сообщений:
	while (GetMessage(&Message, 0, 0, 0))
	{
		TranslateMessage(&Message);
		DispatchMessage(&Message);
	}

	// Close process and thread handles. 
	CloseHandle( pi.hProcess );
	CloseHandle( pi.hThread );

	// Если из цикла вышли, значит пользователь (а может и не он вовсе) закрыл приложение:
	return (int) Message.wParam;
}
