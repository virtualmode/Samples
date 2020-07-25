
#include <stdio.h> // Заголовочный файл с функциями типа sprintf(), printf() и т.п.
#include <windows.h>

#define TEXT_SIZE 128

HWND hWndMain; // Идентификатор основного окна.
HDC hDC; // Контекст устройства для рисования (холст по делфийски).
wchar_t Text[TEXT_SIZE]; // Буфер для вывода строк на экран.
RECT Rect, ClipRect; // Области для скроллинга.
wchar_t Yes[4] = L" ДА", No[4] = L"НЕТ", Down[7] = L"НАЖАТА", Up[7] = L"ОТЖАТА", *Alt, *Previous, *Transition; // Тексты сообщений (нуль символы добавляются автоматически), указатели на текущее состояние клавиш.

// Функция вывода информации о сообщении нажатия клавиши:
void DrawKeyInfo(LPCWSTR Message, bool SysCommand, WPARAM wParam, LPARAM lParam)
{
	ValidateRect(hWndMain, 0); // Говорим системе, чтобы не перерисовывала окно.
	SetBkColor(hDC, RGB(255, 255, 255)); // Ставим цвет заднего фона.
	SetTextColor(hDC, RGB(0, 0, 0)); // Цвет текста.
	ScrollWindow(hWndMain, 0, -13, &Rect, &ClipRect); // Прокручиваем на строчку вверх содержимое окна.
	if (SysCommand == true) Alt = Yes; else Alt = No; // Определяем нажат ли Alt.
	if ((lParam & 0x40000000) == 0) {Previous = Up; Transition = Down; } else { Previous = Down; Transition = Up; } // Получаем состояние нажатия / отжатия клавиши.
	swprintf_s(Text, TEXT_SIZE, L"%s  %04.d    %01.c        %02.d         %03.d       %s    %s       %s\0", Message, wParam, wParam, LOWORD(lParam), (lParam & 0xff0000) >> 16, Alt, Previous, Transition); // Превращаем всю информацию в строку.
	TextOut(hDC, 10, Rect.bottom - 40, Text, (int)wcslen(Text)); // Выводим строку на экран.
}

// Функция обработки сообщений ОС Windows:
LRESULT CALLBACK MainWinProc(HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	switch (Message)
	{
		case WM_PAINT: // Отрисовка шапки таблицы:
			SetBkColor(hDC, RGB(0, 0, 0));
			SetTextColor(hDC, RGB(255, 255, 255));
			TextOut(hDC, 10, 10, L"Сообщение      Код     Символ   Повторов   Сканкод   Alt    Предыдущее   Промежуточное", 86);
			break;

		case WM_SIZE: // Пересчет координат для скроллинга:
			Rect.left = 0;
			Rect.top = 28; // Высота шапки таблицы.
			Rect.right = LOWORD(lParam);
			Rect.bottom = HIWORD(lParam);
			ClipRect.left = 0;
			ClipRect.top = Rect.top;
			ClipRect.right = Rect.right;
			ClipRect.bottom = Rect.bottom - 15; // Отступ от нижней границы окна.
			break;

		case WM_KEYDOWN: // Реакция на нажатие клавиши:
			DrawKeyInfo(L"WM_KEYDOWN   ", false, wParam, lParam);
			break;

		case WM_CHAR: // Реакция на нажатие символа:
			DrawKeyInfo(L"WM_CHAR      ", false, wParam, lParam);
			break;

		case WM_KEYUP: // Реакция на отжатие клавиши:
			DrawKeyInfo(L"WM_KEYUP     ", false, wParam, lParam);
			break;

		case WM_SYSKEYDOWN: // Реакция на нажатие Alt + клавиши:
			DrawKeyInfo(L"WM_SYSKEYDOWN", true, wParam, lParam);
			break;

		case WM_SYSCHAR: // Реакция на нажатие Alt + символа:
			DrawKeyInfo(L"WM_SYSCHAR   ", true, wParam, lParam);
			break;

		case WM_SYSKEYUP: // Реакция на отжатие Alt + клавиши либо реакция на отжатие только Alt'а:
			DrawKeyInfo(L"WM_SYSKEYUP  ", true, wParam, lParam);
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
	hWndMain = CreateWindowEx(0, L"Laboratory", L"Лабораторная работа 3", WS_TILEDWINDOW, 50, 50, 720, 476, 0, 0, hInstance, 0);

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
