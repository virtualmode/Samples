
#include <windows.h>
#include <stdio.h>
#include <stdlib.h>

#define TEXT_SIZE 256
#define RECORDS 6

int i; // Переменная для цикла.
wchar_t Text[RECORDS][TEXT_SIZE]; // Буфер для текста. 0 - Загруженность памяти и т.д.
HWND hWndMain; // Идентификатор основного окна.
RECT Rc;
HDC hDC; // Указатель на контекст для рисования.
HWND hWndControl[2];
HINSTANCE Instance;
LRESULT Result;
WNDPROC DefTextProc; // Указатель на функцию обработки текстового поля.

SYSTEM_INFO si; // Информация о системе.
MEMORY_BASIC_INFORMATION mbi; // Информация об участке памяти.
MEMORYSTATUS ms; // Состояние памяти.

void DrawInfo(LONG_PTR Address)
{
	// Заполнение структур информацией:
	GetSystemInfo(&si);
	GlobalMemoryStatus(&ms);
	VirtualQuery((LPCVOID)Address, &mbi, sizeof(MEMORY_BASIC_INFORMATION));
	swprintf_s(Text[1], TEXT_SIZE, L"Размер страницы: %i байт.", si.dwPageSize);
	swprintf_s(Text[2], TEXT_SIZE, L"Базовый адрес с выравниванием на размер страницы: %i байт.", mbi.BaseAddress);
	swprintf_s(Text[3], TEXT_SIZE, L"Размер региона: %i байт.", mbi.RegionSize);
	swprintf_s(Text[4], TEXT_SIZE, L"Тип региона: ");
	switch (mbi.Type)
	{
		case 0x20000:
			wcscat_s(Text[4], TEXT_SIZE, L"Private.");
			break;

		case 0x40000:
			wcscat_s(Text[4], TEXT_SIZE, L"Mapped.");
			break;

		default:
			wcscat_s(Text[4], TEXT_SIZE, L"Image.");
			break;
	}
	swprintf_s(Text[5], TEXT_SIZE, L"Всего физической памяти: %i байт.", ms.dwTotalPhys);
	SendMessage(hWndMain, WM_PAINT, 0, 0);
}

// Обработка сообщений текстового поля:
LRESULT CALLBACK TextProc(HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	Result = DefTextProc(hWnd, Message, wParam, lParam);
	switch (Message)
	{
		case WM_GETTEXT:
			//DrawInfo(71234);
			// Перерисовываем окно по-корявому (самому противно писать такое):
			GetWindowRect(hWndMain, &Rc);
			MoveWindow(hWndMain, Rc.left, Rc.top, Rc.right - Rc.left + 1, Rc.bottom - Rc.top, TRUE);
			MoveWindow(hWndMain, Rc.left, Rc.top, Rc.right - Rc.left, Rc.bottom - Rc.top, TRUE);
			// Выводим инфу о памяти:
			DrawInfo(_wtoi(Text[0]));
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
									 30, 20, 300, 26, // Размеры текстового поля будут менятся при обработке сообщения WM_SIZE. 
									 hWnd, // Идентификатор родительского окна.
									 (HMENU)0, // Идентификатор элемента.
									 Instance, // Получение идентификатора приложения.
									 0); // Неиспользуемый указатель.
			hWndControl[1] = CreateWindowW(L"BUTTON", L"Выбрать блок памяти", BS_PUSHBUTTON | WS_VISIBLE | WS_CHILD, 340, 20, 200, 25, hWnd, (HMENU)1, Instance, 0);
			DefTextProc = (WNDPROC)GetWindowLong(hWndControl[0], GWL_WNDPROC);
			SetWindowLong(hWndControl[0], GWL_WNDPROC, (LONG)TextProc);
			break;

		case WM_COMMAND:
			switch (LOWORD(wParam))
			{
				case 1:
					SendMessage(hWndControl[0], WM_GETTEXT, TEXT_SIZE, (LPARAM)Text[0]);
					break;

				default:
					break;
			}
			break;

		case WM_PAINT:
			for (i = 1; i < RECORDS; i++) TextOutW(hDC, 30, 75 + i * 25, Text[i], (int)wcslen(Text[i])); // Вывод текста на экран.
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
	hWndMain = CreateWindowEx(0, L"Laboratory", L"Лабораторная работа 14", WS_TILEDWINDOW, 50, 50, 640, 480, 0, 0, hInstance, 0);

	// Вывод информации по-умолчанию:
	DrawInfo(12345); // Вывод информации о секторе памяти.
	SendMessage(hWndControl[0], WM_SETTEXT, 0, (LPARAM)L"12345");

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
