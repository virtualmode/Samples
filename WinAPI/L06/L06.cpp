
#include <stdio.h>
#include <windows.h>

#define TEXT_SIZE 28 // Размер буфера для вывода RGB цвета в текстовом формате. По 9*2 байт на цвет и 2 байта на терминирующий символ.

HINSTANCE Instance; // Идентификатор приложения.
HWND hWndMain; // Идентификатор основного окна.
RECT ClientArea; // Координаты клиентской области окна.
HDC hDC; // Идентификатор контекста для рисования.
HBRUSH Brush; // Кисть для рисования.
HWND hWndScroll[4]; /* Идентификаторы полос прокрутки:
					   0 - Красная полоса прокрутки,
					   1 - Зеленая полоса прокрутки,
					   2 - Синяя полоса прокрутки,
					   3 - Активная полоса.
					*/
SCROLLINFO ScrollInfo[3]; // Информация о состоянии полосы прокрутки.
WNDPROC DefScrollProc; // Указатель на функцию обработки класса "SCROLLBAR".
wchar_t Text[TEXT_SIZE]; // Текстовый буфер.
bool Shift = false;
int i, j, k, t; // Переменные для позиционирования.

// Функция обработки полос прокрутки. Необходима для реализации переходов по нажатию клавиши "Tab":
LRESULT CALLBACK ScrollProc(HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	switch (Message)
	{
		case WM_SETFOCUS: // Полоса с идентификатором hWnd стала активной.
			hWndScroll[3] = hWnd; // Сохраняем идентификатор.
			break;

		case WM_KEYDOWN: // Обработка нажатий клавиш:
			switch (wParam)
			{
				case VK_SHIFT: // Обработка нажатия клавиши "Shift":
					Shift = true;
					break;

				case VK_TAB: // Обработка нажатия клавиши "Tab":
					j = GetWindowLong(hWndScroll[3], GWL_ID);
					if (Shift == false) // Переводим фокус на полосу правее:
					{
						j++;
						if (j > 2) j = 0;
					}
					else // Переводим фокус на полосу левее:
					{
						j--;
						if (j < 0) j = 2;						
					}
					SetFocus(hWndScroll[j]);
					hWndScroll[3] = hWndScroll[j];
					break;
			}
			break;

		case WM_KEYUP: // Обработка отпусканий клавиш:
			if (wParam == VK_SHIFT) Shift = false;
			break;
	}
	return DefScrollProc(hWnd, Message, wParam, lParam); // Запуск функции (по умолчанию) обработки полосы прокрутки.
}

// Функция обработки сообщений ОС Windows:
LRESULT CALLBACK MainWinProc(HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	switch (Message)
	{
		case WM_CREATE: // Инициализация основного окна и создание на нем элементов управления:
			hWndScroll[0] = CreateWindowExW(0L, // Нет дополнительных стилей.
											L"SCROLLBAR", // Название предустановленного класса.
											0, // Текст отсутствует.
											SBS_VERT | WS_VISIBLE | WS_CHILD | WS_TABSTOP, // Стиль.
											0, 0, 0, 0, // Размеры.
											hWnd, // Идентификатор родительского окна.
											(HMENU)0, // Идентификатор элемента.
											Instance, // Получение идентификатора приложения.
											0); // Неиспользуемый указатель.
			hWndScroll[1] = CreateWindowExW(0L, L"SCROLLBAR", 0, SBS_VERT | WS_VISIBLE | WS_CHILD | WS_TABSTOP, 0, 0, 0, 0, hWnd, (HMENU)1, Instance, 0); // Неиспользуемый указатель.
			hWndScroll[2] = CreateWindowExW(0L, L"SCROLLBAR", 0, SBS_VERT | WS_VISIBLE | WS_CHILD | WS_TABSTOP, 0, 0, 0, 0, hWnd, (HMENU)2, Instance, 0); // Неиспользуемый указатель.
			hWndScroll[3] = hWndScroll[0];
			// Подмена функций обработки полос:
			DefScrollProc = (WNDPROC)GetWindowLong(hWndScroll[0], GWL_WNDPROC);
			SetWindowLong(hWndScroll[0], GWL_WNDPROC, (LONG)ScrollProc);
			SetWindowLong(hWndScroll[1], GWL_WNDPROC, (LONG)ScrollProc);
			SetWindowLong(hWndScroll[2], GWL_WNDPROC, (LONG)ScrollProc);
			// Инициализация полос прокрутки:
			ZeroMemory(ScrollInfo, 3 * sizeof(SCROLLINFO)); // Очистка состояния.
			ScrollInfo[0].cbSize = sizeof(SCROLLINFO); // Размер структуры.
			ScrollInfo[0].fMask = SIF_POS | SIF_RANGE | SIF_TRACKPOS; // Стиль полосы прокрутки.
			ScrollInfo[0].nMax = 255; // Максимальная граница прокрутки.
			ScrollInfo[1] = ScrollInfo[0]; // Передача таких же параметров для 2-й и
			ScrollInfo[2] = ScrollInfo[0]; // 3-й структур.
			SetScrollInfo(hWndScroll[0], SB_CTL, &ScrollInfo[0], false); // Установка состояния первой полосы прокрутки.
			SetScrollInfo(hWndScroll[1], SB_CTL, &ScrollInfo[1], false); // Установка состояния второй полосы прокрутки.
			SetScrollInfo(hWndScroll[2], SB_CTL, &ScrollInfo[2], false); // Установка состояния третьей полосы прокрутки.
			return 0;

		/*case WM_SETFOCUS:
			SetFocus(hWndScroll[3]);
			break;*/

		case WM_SIZE: // Обработка изменения размеров основного окна:
			ClientArea.right = LOWORD(lParam);
			ClientArea.bottom = HIWORD(lParam);
			ClientArea.left = ClientArea.right / 2;
			ClientArea.top = 0;
			i = ClientArea.right / 6; // Ширина сектора.
			j = i * 4 / 10; // Ширина полосы прокрутки.
			k = (i - j) / 2; // Смещение полосы прокрутки в секторе.
			t = (i - 74) / 2; // Смещение надписи шириной 74 пиксела.
			MoveWindow(hWndScroll[0], k, 30, j, ClientArea.bottom - 70, true);
			MoveWindow(hWndScroll[1], i + k, 30, j, ClientArea.bottom - 70, true);
			MoveWindow(hWndScroll[2], 2 * i + k, 30, j, ClientArea.bottom - 70, true);
			break;

		case WM_VSCROLL:
			j = GetWindowLong((HWND)lParam, GWL_ID);
			GetScrollInfo((HWND)lParam, SB_CTL, &ScrollInfo[j]);
			switch (LOWORD(wParam))
			{
				case SB_LINEUP: // Нажата одна из клавиш: "Вверх" или "Влево":
					ScrollInfo[j].nPos -= 8;
					break;

				case SB_LINEDOWN: // Нажата одна из клавиш: "Вниз" или "Вправо":
					ScrollInfo[j].nPos += 8;
					break;

				case SB_PAGEUP: // Нажата клавиша "Page Up":
					ScrollInfo[j].nPos -= 32;
					break;

				case SB_PAGEDOWN: // Нажата клавиша "Page Down":
					ScrollInfo[j].nPos += 32;
					break;

				case SB_TOP: // Нажата клавиши "Home":
					ScrollInfo[j].nPos = ScrollInfo[j].nMin;
					break;

				case SB_BOTTOM: // Нажата клавиши "End":
					ScrollInfo[j].nPos = ScrollInfo[j].nMax;
					break;

				case SB_THUMBTRACK: // Пользователь тащит бегунок:
					ScrollInfo[j].nPos = ScrollInfo[j].nTrackPos;
					break;

				default:
					break;
			}
			// Проверка правильности информации, записанной в структуре ScrollInfo[j]:
			if (ScrollInfo[j].nPos < ScrollInfo[j].nMin) ScrollInfo[j].nPos = ScrollInfo[j].nMin;
			else
				if (ScrollInfo[j].nPos > ScrollInfo[j].nMax) ScrollInfo[j].nPos = ScrollInfo[j].nMax;
			SetScrollInfo((HWND)lParam, SB_CTL, &ScrollInfo[j], true); // Применение к полосе прокрутки.
			SendMessage(hWnd, WM_PAINT, 0, 0); // Перерисовка экрана.
			return 0;

		case WM_PAINT: // Метод отрисовки надписей и цветного прямоугольника:
			SetTextColor(hDC, RGB(255, 255, 255));
			// Вывод надписей над полосами:
			SetBkColor(hDC, RGB(255, 0, 0));
			TextOut(hDC, t, 10, L" КРАСНЫЙ ", 9);
			SetBkColor(hDC, RGB(0, 255, 0));
			TextOut(hDC, i + t, 10, L" ЗЕЛЕНЫЙ ", 9);
			SetBkColor(hDC, RGB(0, 0, 255));
			TextOut(hDC, 2 * i + t, 10, L"  СИНИЙ  ", 9);
			// Вывод состояния полос:
			swprintf_s(Text, TEXT_SIZE, L"   %3d      %3d      %3d   ", ScrollInfo[0].nPos, ScrollInfo[1].nPos, ScrollInfo[2].nPos);
			SetBkColor(hDC, RGB(255, 0, 0));
			TextOut(hDC, t, ClientArea.bottom - 30, Text, 9);
			SetBkColor(hDC, RGB(0, 255, 0));
			TextOut(hDC, i + t, ClientArea.bottom - 30, Text + 9, 9);
			SetBkColor(hDC, RGB(0, 0, 255));
			TextOut(hDC, 2 * i + t, ClientArea.bottom - 30, Text + 18, 9);
			// Вывод цветного прямоугольника в правую часть экрана:
			DeleteObject(Brush);
			Brush = CreateSolidBrush(RGB(ScrollInfo[0].nPos, ScrollInfo[1].nPos, ScrollInfo[2].nPos));
			FillRect(hDC, &ClientArea, Brush);
			break;

		case WM_CTLCOLORSCROLLBAR: // Отрисовка фона для каждой из полос:
			DeleteObject(Brush); // Удаляем старую кисть.
			switch (GetWindowLong((HWND)lParam, GWL_ID)) // Определяем текущую полосу прокрутки:
			{
				case 0: // Красная полоса прокрутки:
					Brush = CreateSolidBrush(RGB(255, 0, 0));
					break;

				case 1: // Зеленая полоса прокрутки:
					Brush = CreateSolidBrush(RGB(0, 255, 0));
					break;

				case 2: // Синяя полоса прокрутки:
					Brush = CreateSolidBrush(RGB(0, 0, 255));
					break;
			}
			return (LRESULT)Brush;

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
	
	Instance = hInstance; // Сохраняем идентификатор приложения.

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
	hWndMain = CreateWindowEx(0, L"Laboratory", L"Лабораторная работа 6", WS_TILEDWINDOW | WS_CLIPCHILDREN, 50, 50, 640, 480, 0, 0, hInstance, 0);

	// Отображение всего созданного на экране:
	ShowWindow(hWndMain, SW_SHOWDEFAULT);
	UpdateWindow(hWndMain);

	hDC = GetDC(hWndMain); // Получаем индентификатор контекста для рисования.
	SelectObject(hDC,GetStockObject(ANSI_FIXED_FONT)); // Выбор шрифта с буквами одинаковой ширины.
	Brush = CreateSolidBrush(RGB(0, 0, 0)); // Создаем кисть по умолчанию.
	SendMessage(hWndMain, WM_PAINT, 0, 0); // Перерисовываем окно.

	// Запуск основного цикла обработки сообщений:
	while (GetMessage(&Message, 0, 0, 0))
	{
		TranslateMessage(&Message);
		DispatchMessage(&Message);
	}

	DeleteObject(Brush); // Удаляем кисть.

	// Если из цикла вышли, значит пользователь (а может и не он вовсе) закрыл приложение:
	return (int) Message.wParam;
}
