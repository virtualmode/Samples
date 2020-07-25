
#include <stdio.h>
#include <windows.h>

#define TEXT_SIZE 256

HDC hDC; // Идентификатор контекста для рисования.
RECT Window; // Координаты клиентской области окна (необходимо для очистки экрана).
wchar_t Text[TEXT_SIZE]; // Буфер для временного хранения строк.

// Метод отрисовки прямоугольничка:
void DrawRectangle(int x, int y, int w, int h, COLORREF Color)
{
	RECT Rect;
	HBRUSH Brush = CreateSolidBrush(Color);
	Rect.left = x;
	Rect.top = y;
	Rect.right = x + w;
	Rect.bottom = y + h;
	FillRect(hDC, &Rect, Brush);
	DeleteObject(Brush);
}

// Функция вывода информации о сообщениях мыши и ее положении относительно окна:
void DrawMouseInfo(LPCWSTR Message, WPARAM wParam, LPARAM lParam)
{
	// Затерание заднего фона во избежании глюков в отображении текста:
	DrawRectangle(10, 10, 290, 15, RGB(255, 255, 255));
	// Вывод текста на экран:
	swprintf_s(Text, TEXT_SIZE, L"%s %04.d x %04.d", Message, LOWORD(lParam), HIWORD(lParam)); // Полученные данные преобразуем в строку.
	TextOut(hDC, 10, 10, Text, (int)wcslen(Text));
}

// Функция обработки сообщений ОС Windows:
LRESULT CALLBACK MainWinProc(HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	switch (Message)
	{
		case WM_MOUSEMOVE: // Обработка перемещения мыши по экрану:
			DrawMouseInfo(L"WM_MOUSEMOVE", wParam, lParam);
			break;

		case WM_LBUTTONDOWN: // Обработка нажатия на левую кнопку мыши:
			DrawMouseInfo(L"WM_LBUTTONDOWN", wParam, lParam);
			DrawRectangle(LOWORD(lParam), HIWORD(lParam), 6, 6, RGB(0, 255, 0));
			break;

		case WM_LBUTTONUP: // Обработка отжатия левой кнопки мыши:
			DrawMouseInfo(L"WM_LBUTTONUP", wParam, lParam);
			if (wParam == MK_RBUTTON) // Проверка на одновременное нажатие левой и правой кнопок мыши:
			{
				GetModuleFileNameA(0, (char*)Text, TEXT_SIZE); // Получение пути к файлу текущего процесса.
				WinExec((char*)Text, SW_SHOW); // Запуск еще одного процесса.
			}
			break;

		case WM_RBUTTONDOWN: // Обработка нажатия на правую кнопку мыши:
			DrawMouseInfo(L"WM_RBUTTONDOWN", wParam, lParam);
			DrawRectangle(LOWORD(lParam), HIWORD(lParam), 6, 6, RGB(255, 0, 0));
			break;

		case WM_RBUTTONUP: // Обработка отжатия правой кнопки мыши:
			DrawMouseInfo(L"WM_RBUTTONUP", wParam, lParam);
			break;

		case WM_LBUTTONDBLCLK: // Очистка экрана при двойном нажатии левой кнопки мыши:
			DrawRectangle(0, 0, Window.right, Window.bottom, RGB(255, 255, 255));
			break;

		case WM_RBUTTONDBLCLK: // Переключение захвата при двойном нажатии правой кнопки мыши.
			if (GetCapture() == 0) // Если мышь не захвачена, то...
				SetCapture(hWnd); // Захватываем её.
			else
				ReleaseCapture(); // Освобождаем.
			break;

		case WM_SIZE: // Получение новых размеров окна (необходимо для равильной очистки окна):
			Window.right = LOWORD(lParam);
			Window.bottom = HIWORD(lParam);
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
	hWndMain = CreateWindowEx(0, L"Laboratory", L"Лабораторная работа 4", WS_TILEDWINDOW, CW_USEDEFAULT, 0, 640, 480, 0, 0, hInstance, 0);

	// Отображение всего созданного на экране:
	ShowWindow(hWndMain, SW_SHOW);
	UpdateWindow(hWndMain);

	// Получение идентификатора контекста для рисования:
	hDC = GetDC(hWndMain);

	// Запуск основного цикла обработки сообщений:
	while (GetMessage(&Message, 0, 0, 0))
	{
		TranslateMessage(&Message);
		DispatchMessage(&Message);
	}

	// Если из цикла вышли, значит пользователь (а может и не он вовсе) закрыл приложение:
	return (int) Message.wParam;
}
