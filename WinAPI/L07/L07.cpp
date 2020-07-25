
#include <windows.h>

HINSTANCE Instance; // Идентификатор приложения.
HWND hWndEdit; // Идентификатор текстового поля.

// Функция обработки сообщений ОС Windows:
LRESULT CALLBACK MainWinProc(HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	switch (Message)
	{
		case WM_CREATE: // Инициализация основного окна и создание на нем текстового поля:
			hWndEdit = CreateWindowW(L"EDIT", // Название предустановленного класса.
									 0, // Нет заголовка.
									 WS_CHILD | WS_VISIBLE | WS_VSCROLL | ES_LEFT | ES_MULTILINE | ES_AUTOVSCROLL, // Стиль текстового поля.
									 0, 0, 0, 0, // Размеры текстового поля будут менятся при обработке сообщения WM_SIZE. 
									 hWnd, // Идентификатор родительского окна.
									 (HMENU)0, // Идентификатор элемента.
									 Instance, // Получение идентификатора приложения.
									 0); // Неиспользуемый указатель. 
			// Установка текста по умолчанию:
			SendMessageW(hWndEdit, WM_SETTEXT, 0, (LPARAM)L"Лабораторная работа по системному программированию №7."); 
			return 0;

		case WM_SETFOCUS: // Установка фокуса на текстовое поле.
			SetFocus(hWndEdit); 
			return 0;

		case WM_SIZE: // Обработка изменения размеров основного окна:
			MoveWindow(hWndEdit, // Идентификатор текстового поля.
					   0, 0, // Координаты левого верхнего угла для текстового поля.
					   LOWORD(lParam), // Ширина клиентской области.
					   HIWORD(lParam), // Высота клиентской области.
					   TRUE); // Перерисовать окно.
			return 0;

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
	hWndMain = CreateWindowEx(0, L"Laboratory", L"Лабораторная работа 7", WS_TILEDWINDOW, 50, 50, 640, 480, 0, 0, hInstance, 0);

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
