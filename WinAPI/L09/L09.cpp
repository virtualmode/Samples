
#include <windows.h>
#include "Resource.h" // Заголовочный файл ресурсов с меню и его элементами.

bool CheckBox1 = true, CheckBox2 = true; // Состояние чекбоксов меню.

// Функция обработки сообщений ОС Windows:
LRESULT CALLBACK MainWinProc(HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	switch (Message)
	{
		case WM_COMMAND:
			switch(LOWORD(wParam)) 
			{
				case IDR_EXIT: // Обработка нажатия на "Выход":
					SendMessage(hWnd, WM_CLOSE, 0, 0);
					break;

				case IDR_CHECKBOX1: // Обработка нажатия на чекбокс 1:
					if (CheckBox1 == true)
					{
						CheckBox1 = false;
						CheckMenuItem(GetMenu(hWnd), IDR_CHECKBOX1, MF_UNCHECKED);
					}
					else
					{
						CheckBox1 = true;
						CheckMenuItem(GetMenu(hWnd), IDR_CHECKBOX1, MF_CHECKED);
					}
					break;

				case IDR_CHECKBOX2: // Обработка нажатия на чекбокс 2:
					if (CheckBox2 == true)
					{
						CheckBox2 = false;
						CheckMenuItem(GetMenu(hWnd), IDR_CHECKBOX2, MF_UNCHECKED);
					}
					else
					{
						CheckBox2 = true;
						CheckMenuItem(GetMenu(hWnd), IDR_CHECKBOX2, MF_CHECKED);
					}
					break;

				case IDR_ABOUT: // Обработка нажатия на "О программе...":
					MessageBox(hWnd, L"Лабораторная работа по системному программированию №9.", L"О программе...", 0);
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
	return (DefWindowProc(hWnd, Message, wParam, lParam));
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
	WindowClassEx.lpszMenuName = MAKEINTRESOURCE(101); // Идентификатор меню.
	WindowClassEx.lpszClassName = L"Laboratory"; // Имя класса. Используется операционной системой.
	WindowClassEx.hIconSm = LoadIcon(0, MAKEINTRESOURCE(32517)); // Какая-то иконка по умолчанию.

	RegisterClassEx(&WindowClassEx); // Регистрация класса окна, информация о котором берется из вышеописанной структуры.

	// Создание основного окна:
	hWndMain = CreateWindowEx(0, L"Laboratory", L"Лабораторная работа 9", WS_TILEDWINDOW, 50, 50, 640, 480, 0, 0, hInstance, 0);

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
