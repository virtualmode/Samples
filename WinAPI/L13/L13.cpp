
#include <stdio.h>
#include <stdlib.h>
#include <process.h>
#include <windows.h>

#define TEXT_SIZE 128

struct Thread
{
	HANDLE hThread;
	unsigned Id;
};

int k, n, p; // n - номер потока, p - приоритет.
HDC hDC; // Указатель на контекст для рисования.
HWND hWndControl[4];
Thread Threads[2];
HINSTANCE Instance;
LRESULT Result;
WNDPROC DefTextProc; // Указатель на функцию обработки текстового поля.
wchar_t Text[TEXT_SIZE];

// Обработка сообщений текстового поля:
LRESULT CALLBACK TextProc(HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	Result = DefTextProc(hWnd, Message, wParam, lParam);
	switch (Message)
	{
		case WM_GETTEXT:
			// Обработка полученных данных:
			k = 0;
			n = 1;
			p = 0;
			while (Text[k] != 0 && Text[k] != L',')
			{
				k++;
			}
			Text[k] = 0;
			n = _wtoi(Text) - 1;
			p = _wtoi(Text + k + 1);
			if (n >= 0 && n < 2)
			{
				if (!SetThreadPriority(Threads[n].hThread, p))
				{
					MessageBox(0, L"Невозможно изменить приоритет.", L"", 0);
				}
				else
				{
					swprintf(Text, TEXT_SIZE, L"Поток %i [Приоритет %i]", n + 1, p);
					SendMessage(hWndControl[n], WM_SETTEXT, 0, (LPARAM)Text);
				}
			}
			else
			{
				MessageBox(0, L"Введенный поток отсутствует.", L"", 0);
			}
			break;

		default:
			break;
	}
	return Result;
}

// Функция, работающая в первом потоке. Ее задача - тупо подвигать кнопку 1:
unsigned __stdcall FirstThreadFunc( void* pArguments )
{
	bool d = false;
	int x = 30;
	for (int i = 0; i < 1480; i++)
	{
		Sleep(1);
		if (d == false) x++; else x--;
		if (x > 400) d = true; else if (x < 30) d = false;
		MoveWindow(hWndControl[0], x, 75, 250, 25, TRUE);
	}
	return 0;
}

// Функция, работающая в первом потоке. Ее задача - тупо подвигать кнопку 2:
unsigned __stdcall SecondThreadFunc( void* pArguments )
{
	bool d = false;
	int y = 105;
	for (int i = 0; i < 600; i++)
	{
		Sleep(1);
		if (d == false) y++; else y--;
		if (y > 205) d = true; else if (y < 105) d = false;
		MoveWindow(hWndControl[1], 30, y, 250, 25, TRUE);
	}
	return 0;
}

// Функция обработки сообщений ОС Windows (!!! ЭТА ФУНКЦИЯ РАБОТАЕТ В ОСНОВНОМ ПОТОКЕ):
LRESULT CALLBACK MainWinProc(HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	switch (Message)
	{
		case WM_CREATE: // Инициализация основного окна и создание на нем элементов управления:
			hWndControl[0] = CreateWindowW(L"BUTTON", L"Поток 1 [Приоритет 0]", BS_PUSHBUTTON | WS_VISIBLE | WS_CHILD, 30, 75, 250, 25, hWnd, (HMENU)0, Instance, 0);
			hWndControl[1] = CreateWindowW(L"BUTTON", L"Поток 2 [Приоритет 0]", BS_PUSHBUTTON | WS_VISIBLE | WS_CHILD, 30, 105, 250, 25, hWnd, (HMENU)1, Instance, 0);
			hWndControl[2] = CreateWindowW(L"EDIT", 0, WS_CHILD | WS_BORDER | WS_VISIBLE | ES_LEFT, 30, 30, 200, 26, hWnd, (HMENU)2, Instance, 0); // Неиспользуемый указатель.
			hWndControl[3] = CreateWindowW(L"BUTTON", L"Установить приоритет [Номер потока, Приоритет]", BS_PUSHBUTTON | WS_VISIBLE | WS_CHILD, 240, 30, 350, 25, hWnd, (HMENU)3, Instance, 0);
			DefTextProc = (WNDPROC)GetWindowLong(hWndControl[2], GWL_WNDPROC);
			SetWindowLong(hWndControl[2], GWL_WNDPROC, (LONG)TextProc);
			break;

		case WM_PAINT:
			TextOutW(hDC, 30, 350, L"Варианты приоритета:  -15  -2  -1  0  1  2  15", 46); // Вывод текста на экран.
			break;

		case WM_COMMAND:
			switch (LOWORD(wParam))
			{
				case 0:
					// Создание потока:
					Threads[0].hThread = (HANDLE)_beginthreadex(NULL, 0, &FirstThreadFunc, NULL, 0, &Threads[0].Id);
					break;

				case 1:
					Threads[1].hThread = (HANDLE)_beginthreadex(NULL, 0, &SecondThreadFunc, NULL, 0, &Threads[1].Id);
					break;

				case 3:
					SendMessage(hWndControl[2], WM_GETTEXT, TEXT_SIZE, (LPARAM)Text);
					break;

				default:
					break;
			}
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
	hWndMain = CreateWindowEx(0, L"Laboratory", L"Лабораторная работа 13", WS_TILEDWINDOW, 50, 50, 640, 480, 0, 0, hInstance, 0);

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

	// Destroy the thread object.
	CloseHandle(Threads[0].hThread);
	CloseHandle(Threads[1].hThread);

	// Если из цикла вышли, значит пользователь (а может и не он вовсе) закрыл приложение:
	return (int) Message.wParam;
}
