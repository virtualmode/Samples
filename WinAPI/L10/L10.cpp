
#include <windows.h>

// Функция обработки сообщений ОС Windows:
LRESULT CALLBACK MainWinProc(HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	switch (Message)
	{
		case WM_SYSCOMMAND: // Обработка сообщений системного меню:
			switch (wParam)
			{
				case 0: // Первый (и единственный) элемент меню:
					MessageBox(hWnd, L"Лабораторная работа по системному программированию №10.", L"О программе...", 0);
					break;

				default:
					break;
			}
			break;

		case WM_PAINT: // Перерисовка окна:
			TextOut(GetDC(hWnd), 30, 50, L"Для открытия системного меню нажмите правой кнопкой миши на заголовке окна.", 75);
			break;

		case WM_DESTROY: // Уничтожение окна:
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
	hWndMain = CreateWindowEx(0, L"Laboratory", L"Лабораторная работа 10", WS_TILEDWINDOW, 50, 50, 640, 480, 0, 0, hInstance, 0);
	
	HMENU SystemMenu = GetSystemMenu(hWndMain, false); // Получение идентификатора системного меню.
	MENUITEMINFOW MenuItem; // Создание структуры для хранения информации об элементе меню.
	ZeroMemory(&MenuItem, sizeof(MENUITEMINFOW)); // Очистка структуры.
	MenuItem.cbSize = sizeof(MENUITEMINFOW); // Задание размера структуры.
	InsertMenuItem(SystemMenu, 7, true, &MenuItem); // Добавление сепаратора в системное меню.
	MenuItem.fMask = MIIM_TYPE; // Установка типа для следующего элемента меню.
	MenuItem.dwTypeData = L"О 10-ой лабораторной..."; // Установка текста для элемента меню.
	InsertMenuItem(SystemMenu, 8, true, &MenuItem); // Добавление элемента в системное меню.
	
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
