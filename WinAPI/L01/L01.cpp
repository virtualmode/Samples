
#include <windows.h>

// Функция обработки сообщений ОС Windows:
LRESULT CALLBACK MainWinProc(HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	switch (Message)
	{
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
	HWND hWndMain, hWndChild, hWndDialogP, hWndP; // Идентификаторы основного окна, дочернего, диалогового всплывающего и просто всплывающего.
	MSG Message; // Переменная для обработки сообщений.
	
	// Заполнение структуры WindowClassEx:
	WindowClassEx.cbSize = sizeof(WNDCLASSEX);
	WindowClassEx.style = CS_DBLCLKS | CS_OWNDC | CS_HREDRAW | CS_VREDRAW; // Не напрягайтесь, это просто флаги. К лабораторной не имеют никакого отношения.
	WindowClassEx.lpfnWndProc = MainWinProc; // Указатель на функцию обработки сообщений ОС Windows. Осторожно! В данной лабе все окна обрабатываются одной функцией.
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
	hWndMain = CreateWindowEx(0, L"Laboratory", L"Лабораторная работа 1", WS_SIZEBOX | WS_VISIBLE | WS_POPUPWINDOW | WS_CAPTION, 50, 50, 640, 480, 0, 0, hInstance, 0);
	
	// Создание дочернего окна:
	hWndChild = CreateWindowEx(0, L"Laboratory", L"Дочернее окно", WS_VISIBLE | WS_OVERLAPPED | WS_CHILD | WS_CAPTION, 10, 10, 320, 200, hWndMain, NULL, hInstance, 0);

	// Создание диалогового Pop-up окна:
	hWndDialogP = CreateWindowEx(0, L"Laboratory", L"Диалоговое Pop-up окно", WS_VISIBLE | WS_POPUPWINDOW | WS_CAPTION, 65, 300, 320, 200, hWndMain, NULL, hInstance, 0);

	// Создание простого Pop-up окна:
	hWndP = CreateWindowEx(0, L"Laboratory", L"Pop-up окно", WS_VISIBLE | WS_POPUPWINDOW | WS_CAPTION, 200, 200, 320, 200, NULL, NULL, hInstance, 0);

	// Отображение всего созданного на экране:
	ShowWindow(hWndMain, SW_SHOWDEFAULT);
	UpdateWindow(hWndMain);

	// Запуск основного цикла обработки сообщений:
	while (GetMessage(&Message, 0, 0, 0))
	{
		TranslateMessage(&Message);
		DispatchMessage(&Message);
	}

	// Если из цикла вышли, значит пользователь (а может и не он вовсе) закрыл приложение:
	return (int) Message.wParam;
}
