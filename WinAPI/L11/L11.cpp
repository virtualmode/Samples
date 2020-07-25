
#include <windows.h>
#include <stdlib.h>
#include <stdio.h>

#define TEXT_SIZE 256 // Размер одной записи.
#define RECORDS 4 // Количество записей в окне.
#define CONTROLS 10 // Количество контролов.

int i, cid; // cid - индекс нажатой кнопки.
wchar_t Text[RECORDS][TEXT_SIZE], *Ptr; // Буфер для текста.
HDC hDC; // Указатель на контекст для рисования.
HWND hWndControl[CONTROLS];
HINSTANCE Instance;
LRESULT Result;
WNDPROC DefTextProc; // Указатель на функцию обработки текстового поля.

HMODULE m; // Идентификатор текущего процесса.
OSVERSIONINFO osv;

// Обработка сообщений текстового поля:
LRESULT CALLBACK TextProc(HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	Result = DefTextProc(hWnd, Message, wParam, lParam);
	switch (Message)
	{
		case WM_GETTEXT:
			switch (cid)
			{
				case 2: // Получение Id модуля по его имени:
					swprintf_s(Text[2], TEXT_SIZE, L"Id модуля '%s' = %i.", Text[0], GetModuleHandle(Text[0]));
					MessageBox(0, Text[2], L"", 0);
					break;

				case 3: // Получение имени модуля по его Id:
					GetModuleFileName((HMODULE)_wtoi(Text[0]), Text[2], TEXT_SIZE);
					swprintf_s(Text[3], TEXT_SIZE, L"Имя модуля с идентификатором '%s' = %s.", Text[0], Text[2]);
					MessageBox(0, Text[3], L"", 0);
					break;

				case 4: // Получение командной строки:
					MessageBox(0, GetCommandLine(), L"", 0);
					break;

				case 5: // Получение текущего каталога:
					GetCurrentDirectory(TEXT_SIZE, Text[2]);
					swprintf_s(Text[3], TEXT_SIZE, L"Текущий каталог = %s.", Text[2]);
					MessageBox(0, Text[3], L"", 0);
					break;

				case 6: // Установка каталога:
					if (SetCurrentDirectory(Text[0])) MessageBox(0, L"Текущий каталог установлен.", L"", 0); else MessageBox(0, L"Текущий каталог не установлен. Неверный параметр.", L"", 0);
					break;

				case 7: // Прочесть переменную окружения:
					if (GetEnvironmentVariable(Text[0], Text[2], TEXT_SIZE) != 0)
					{
						swprintf_s(Text[3], TEXT_SIZE, L"Значение переменной окружения '%s' = %s.", Text[0], Text[2]);
						MessageBox(0, Text[3], L"", 0);
					}
					else
					{
						MessageBox(0, L"Не удалось прочесть переменную окружения.", L"", 0);
					}
					break;

				case 8: // Запись переменной окружения:
					i = 0;
					while (Text[0][i] != 0 && Text[0][i] != L'=') i++;
					Text[0][i] = 0;
					if (SetEnvironmentVariable(Text[0], Text[0] + i + 1))
					{
						swprintf_s(Text[2], TEXT_SIZE, L"Переменная '%s' изменена.", Text[0]);
						MessageBox(0, Text[2], L"", 0);
					}
					else
					{
						MessageBox(0, L"Не удалось изменить переменную окружения.", L"", 0);
					}
					break;

				case 9: // Получение адреса блока переменных окружения:
					Ptr = GetEnvironmentStrings();
					if (Ptr != 0)
					{
						swprintf_s(Text[2], TEXT_SIZE, L"Адрес блока = %i", Ptr);
						MessageBox(0, Text[2], L"", 0);
					}
					else
					{
						MessageBox(0, L"Не удалось прочесть адрес блока переменных окружения.", L"", 0);
					}
					break;

				default: // Загрузка модуля:
					if (LoadLibrary(Text[0]))
						MessageBox(0, L"Модуль успешно загружен.", L"", 0);
					else
						MessageBox(0, L"Не удалось загрузить модуль.", L"", 0);
					break;
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
									 0, // Нет заголовка.
									 WS_CHILD | WS_BORDER | WS_VISIBLE | ES_LEFT, // Стиль текстового поля.
									 30, 20, 450, 26, // Размеры текстового поля будут менятся при обработке сообщения WM_SIZE. 
									 hWnd, // Идентификатор родительского окна.
									 (HMENU)0, // Идентификатор элемента.
									 Instance, // Получение идентификатора приложения.
									 0); // Неиспользуемый указатель.
			hWndControl[1] = CreateWindowW(L"BUTTON", L"Загрузить модуль [Путь к модулю]", BS_PUSHBUTTON | WS_VISIBLE | WS_CHILD, 30, 60, 450, 25, hWnd, (HMENU)1, Instance, 0);
			hWndControl[2] = CreateWindowW(L"BUTTON", L"Получить Id модуля по его имени [Имя модуля]", BS_PUSHBUTTON | WS_VISIBLE | WS_CHILD, 30, 95, 450, 25, hWnd, (HMENU)2, Instance, 0);
			hWndControl[3] = CreateWindowW(L"BUTTON", L"Получить имя модуля по его Id [Идентификатор]", BS_PUSHBUTTON | WS_VISIBLE | WS_CHILD, 30, 130, 450, 25, hWnd, (HMENU)3, Instance, 0);
			hWndControl[4] = CreateWindowW(L"BUTTON", L"Получить командную строку процесса", BS_PUSHBUTTON | WS_VISIBLE | WS_CHILD, 30, 165, 450, 25, hWnd, (HMENU)4, Instance, 0);
			hWndControl[5] = CreateWindowW(L"BUTTON", L"Получить текущий каталог", BS_PUSHBUTTON | WS_VISIBLE | WS_CHILD, 30, 200, 450, 25, hWnd, (HMENU)5, Instance, 0);
			hWndControl[6] = CreateWindowW(L"BUTTON", L"Установить текущий каталог [Каталог]", BS_PUSHBUTTON | WS_VISIBLE | WS_CHILD, 30, 235, 450, 25, hWnd, (HMENU)6, Instance, 0);
			hWndControl[7] = CreateWindowW(L"BUTTON", L"Прочесть переменную окружения [Имя переменной]", BS_PUSHBUTTON | WS_VISIBLE | WS_CHILD, 30, 270, 450, 25, hWnd, (HMENU)7, Instance, 0);
			hWndControl[8] = CreateWindowW(L"BUTTON", L"Установить переменную окружения [Имя = Значение]", BS_PUSHBUTTON | WS_VISIBLE | WS_CHILD, 30, 305, 450, 25, hWnd, (HMENU)8, Instance, 0);
			hWndControl[9] = CreateWindowW(L"BUTTON", L"Получить адрес блока переменных окружения", BS_PUSHBUTTON | WS_VISIBLE | WS_CHILD, 30, 340, 450, 25, hWnd, (HMENU)9, Instance, 0);

			DefTextProc = (WNDPROC)GetWindowLong(hWndControl[0], GWL_WNDPROC);
			SetWindowLong(hWndControl[0], GWL_WNDPROC, (LONG)TextProc);
			break;

		case WM_COMMAND:
			cid = LOWORD(wParam);
			if (cid > 0 && cid < CONTROLS) SendMessage(hWndControl[0], WM_GETTEXT, TEXT_SIZE, (LPARAM)Text);
			break;

		case WM_PAINT:
			TextOutW(hDC, 35, 410, Text[1], (int)wcslen(Text[1]));
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

	// Заполнение структур:
	ZeroMemory(&osv, sizeof(OSVERSIONINFO));
	osv.dwOSVersionInfoSize = sizeof(OSVERSIONINFO);
	GetVersionEx(&osv);
	swprintf_s(Text[1], TEXT_SIZE, L"Версия системы: %i.%i ", osv.dwMajorVersion, osv.dwMinorVersion);
	switch (osv.dwPlatformId)
	{
		case 1:
			wcscat_s(Text[1], TEXT_SIZE, L"Семейство Windows 9x.");
			break;

		case 2:
			wcscat_s(Text[1], TEXT_SIZE, L"Семейство Windows NT.");
			break;

		default:
			wcscat_s(Text[1], TEXT_SIZE, L"Windows 3.1.");
			break;
	}
	
	// Создание основного окна:
	hWndMain = CreateWindowEx(0, L"Laboratory", L"Лабораторная работа 11", WS_TILEDWINDOW, 50, 50, 640, 480, 0, 0, hInstance, 0);
	SendMessage(hWndControl[0], WM_SETTEXT, 0, (LPARAM)L"C:\\WINDOWS\\NOTEPAD.EXE");

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
