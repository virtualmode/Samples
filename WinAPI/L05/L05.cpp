
#include <stdio.h>
#include <windows.h>

#define TEXT_SIZE 128 // Размер текстового буфера.

HINSTANCE Instance; // Идентификатор приложения.
HWND hWndMain; // Идентификатор основного окна.
HDC hDC; // Идентификатор контекста для рисования.
wchar_t Text[TEXT_SIZE]; // Буфер для вывода строк на экран.
RECT Rect, ClipRect; // Области для скроллинга.
HWND hWndControl[11]; /* Идентификаторы объектов основного окна:
						  0 - BS_GROUPBOX,
						  1 - BS_PUSHBUTTON,
						  2 - BS_DEFPUSHBUTTON,
						  3 - BS_USERBUTTON,
						  4 - BS_OWNERDRAW,
						  5 - BS_CHECKBOX,
						  6 - BS_AUTOCHECKBOX,
						  7 - BS_3STATE,
						  8 - BS_AUTO3STATE,
						  9 - BS_RADIOBUTTON,
						 10 - BS_AUTORADIOBUTTON.
					  */

// Функция вывода информации о взаимодействии пользователя с элементами основного окна:
void DrawControlInfo(WPARAM wParam, LPARAM lParam)
{
	ValidateRect(hWndMain, 0); // Говорим системе, чтобы не перерисовывала окно.
	SetBkColor(hDC, RGB(255, 255, 255)); // Ставим цвет заднего фона.
	SetTextColor(hDC, RGB(0, 0, 0)); // Цвет текста.
	ScrollWindow(hWndMain, 0, -13, &Rect, &ClipRect); // Прокручиваем на строчку вверх содержимое окна.
	swprintf_s(Text, TEXT_SIZE, L"%11.d               %10.d                  %d\0", LOWORD(wParam), lParam, HIWORD(wParam)); // Превращаем всю информацию в строку.
	TextOut(hDC, 220, Rect.bottom - 40, Text, (int)wcslen(Text)); // Выводим строку на экран.
}

// Функция обработки сообщений ОС Windows:
LRESULT CALLBACK MainWinProc(HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	switch (Message)
	{
		case WM_CREATE: // Инициализация основного окна и создание на нем элементов управления:
			hWndControl[0] = CreateWindowW(L"BUTTON", // Название предустановленного класса.
										   L"BS_GROUPBOX", // Текст кнопки.
										   BS_GROUPBOX | WS_VISIBLE | WS_CHILD, // Стиль.
										   10, 10, 200, 381, // Размеры.
										   hWnd, // Идентификатор родительского окна.
										   (HMENU)0, // Идентификатор элемента.
										   Instance, // Получение идентификатора приложения.
										   0); // Неиспользуемый указатель.
			hWndControl[1] = CreateWindowW(L"BUTTON", L"BS_PUSHBUTTON", BS_PUSHBUTTON | WS_VISIBLE | WS_CHILD, 20, 37, 177, 25, hWnd, (HMENU)1, Instance, 0);
			hWndControl[2] = CreateWindowW(L"BUTTON", L"BS_DEFPUSHBUTTON", BS_DEFPUSHBUTTON | WS_VISIBLE | WS_CHILD, 20, 72, 177, 25, hWnd, (HMENU)2, Instance, 0);
			hWndControl[3] = CreateWindowW(L"BUTTON", L"BS_USERBUTTON", BS_USERBUTTON | WS_VISIBLE | WS_CHILD, 20, 107, 177, 25, hWnd, (HMENU)3, Instance, 0);
			hWndControl[4] = CreateWindowW(L"BUTTON", L"BS_OWNERDRAW", BS_OWNERDRAW | WS_VISIBLE | WS_CHILD, 20, 142, 177, 25, hWnd, (HMENU)4, Instance, 0);
			hWndControl[5] = CreateWindowW(L"BUTTON", L"BS_CHECKBOX", BS_CHECKBOX | WS_VISIBLE | WS_CHILD, 20, 177, 177, 25, hWnd, (HMENU)5, Instance, 0);
			hWndControl[6] = CreateWindowW(L"BUTTON", L"BS_AUTOCHECKBOX", BS_AUTOCHECKBOX | WS_VISIBLE | WS_CHILD, 20, 212, 177, 25, hWnd, (HMENU)6, Instance, 0);
			hWndControl[7] = CreateWindowW(L"BUTTON", L"BS_3STATE", BS_3STATE | WS_VISIBLE | WS_CHILD, 20, 247, 177, 25, hWnd, (HMENU)7, Instance, 0);
			hWndControl[8] = CreateWindowW(L"BUTTON", L"BS_AUTO3STATE", BS_AUTO3STATE | WS_VISIBLE | WS_CHILD, 20, 282, 177, 25, hWnd, (HMENU)8, Instance, 0);
			hWndControl[9] = CreateWindowW(L"BUTTON", L"BS_RADIOBUTTON", BS_RADIOBUTTON | WS_VISIBLE | WS_CHILD, 20, 317, 177, 25, hWnd, (HMENU)9, Instance, 0);
			hWndControl[10] = CreateWindowW(L"BUTTON", L"BS_AUTORADIOBUTTON", BS_AUTORADIOBUTTON | WS_VISIBLE | WS_CHILD, 20, 352, 177, 25, hWnd, (HMENU)10, Instance, 0);
			return 0;

		case WM_PAINT: // Отрисовка шапки таблицы:
			SetBkColor(hDC, RGB(0, 0, 0));
			SetTextColor(hDC, RGB(255, 255, 255));
			TextOut(hDC, 220, 18, L"   LOWORD(wParam)            lParam             HIWORD(wParam)  ", 64);
			TextOut(hDC, 220, 30, L" Control identifier       Window handle       Notification code ", 64);
			break;

		case WM_SIZE: // Пересчет координат для скроллинга:
			Rect.left = 220;
			Rect.top = 52; // Высота шапки таблицы.
			Rect.right = LOWORD(lParam);
			Rect.bottom = HIWORD(lParam);
			ClipRect.left = Rect.left;
			ClipRect.top = Rect.top;
			ClipRect.right = Rect.right;
			ClipRect.bottom = Rect.bottom - 15; // Отступ от нижней границы окна.
			break;

		case WM_COMMAND: // Обработка взаимодействий с элементами основного окна:
			DrawControlInfo(wParam, lParam);
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
	hWndMain = CreateWindowEx(0, L"Laboratory", L"Лабораторная работа 5", WS_TILEDWINDOW, 50, 50, 755, 435, 0, 0, hInstance, 0);

	// Отображение всего созданного на экране:
	ShowWindow(hWndMain, SW_SHOWDEFAULT);
	UpdateWindow(hWndMain);

	hDC = GetDC(hWndMain); // Получаем индентификатор контекста для рисования.
	SelectObject(hDC,GetStockObject(ANSI_FIXED_FONT)); // Выбор шрифта с буквами одинаковой ширины.
	SendMessage(hWndMain, WM_PAINT, 0, 0); // Перерисовываем окно.

	// Запуск основного цикла обработки сообщений:
	while (GetMessage(&Message, 0, 0, 0))
	{
		TranslateMessage(&Message);
		DispatchMessage(&Message);
	}

	// Если из цикла вышли, значит пользователь (а может и не он вовсе) закрыл приложение:
	return (int) Message.wParam;
}
