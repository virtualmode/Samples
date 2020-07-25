
#include <stdio.h>
#include <windows.h>

#define TEXT_SIZE 256

HINSTANCE Instance; // Идентификатор приложения.
HWND hWndMain, hWndList; // Идентификатор основного окна, идентификатор списка.
HDC hDC; // Идентификатор контекста для рисования.
RECT ClientArea; // Координаты клиентской области основного окна.
HBRUSH Brush; // Кисть для закрашивания заднего фона текста в белый цвет.
wchar_t CurrentDir[TEXT_SIZE], Text[TEXT_SIZE], Buffer[TEXT_SIZE]; // Текущий каталог, буфер для вывода текста в клиентскую часть окна, просто текстовый буфер.
WNDPROC DefListProc; // Указатель на функцию обработки списка по умолчанию.

// Функция отображения содержимого директории с помощью списка:
void SetListDir(LPCWSTR Path)
{
	// Избавляемся от "..":
	SetCurrentDirectory(Path);
	GetCurrentDirectory(TEXT_SIZE, CurrentDir);
	// Инициализация переменных:
	wchar_t Buffer[TEXT_SIZE]; // Буфер для работы со строками.
	WIN32_FIND_DATA File; // Информация о текущем найденном файле.
	HANDLE Handle = INVALID_HANDLE_VALUE; // Результат последнего поиска.
	// Очистка списка:
	SendMessage(hWndList, LB_RESETCONTENT, 0, 0);
	// Поиск первого попавшегося файла "[.]":
	swprintf_s(Buffer, TEXT_SIZE, L"%s%s", Path, L"\\*");
	Handle = FindFirstFile(Buffer, &File);
	// Поиск родительского каталога "[..]":
	FindNextFile(Handle, &File);
	SendMessage(hWndList, LB_ADDSTRING, 0, (LPARAM)L"[..]");
	// Поиск остальных элементов каталога:
	while (FindNextFile(Handle, &File)) // Поиск очередного файла или каталога.
	{
		swprintf_s(Buffer, TEXT_SIZE, L"%s\\%s", Path, File.cFileName); // Полный путь к найденному элементу.
		SendMessage(hWndList, LB_ADDFILE, 0, (LPARAM)Buffer); // Добавление очередного найденного элемента в список.
	}
	FindClose(Handle); // Поиск закончен.
	if (CurrentDir[3] == '\0') CurrentDir[2] = '\0'; // Обрезаем бэкслэш, если дошли до корневого каталога тома.
	swprintf_s(Text, TEXT_SIZE, L"%s\\", CurrentDir); // Добавляем бэкслэш к текущему каталогу.
	SendMessage(hWndMain, WM_PAINT, 0, 0); // Перерисовываем строку в нижней части основного окна.
}

// Функция удаления скобок:
void DeleteBrk(LPCWSTR ListString)
{
	CopyMemory(Text, ListString + 1, wcslen(ListString) * 2 - 4);
	Text[wcslen(ListString) - 2] = '\0';
	CopyMemory((void*)ListString, Text, wcslen(Text) * 2 + 2);
}

// Функция обработки взаимодействий со списком:
LRESULT CALLBACK ListProc(HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	switch (Message)
	{
		case WM_LBUTTONDBLCLK:
			SendMessage(hWndList, LB_GETTEXT, (LPARAM)SendMessage(hWndList, LB_GETCURSEL, 0, 0), (WPARAM)Buffer); // В буфере хранится текст выделенной строки.
			if (Buffer[0] != '[') // Найден файл, выводим его в нижнюю часть экрана:
			{
				swprintf_s(Text, TEXT_SIZE, L"%s\\%s", CurrentDir, Buffer);
				SendMessage(hWndMain, WM_PAINT, 0, 0);
			}
			else
			{
				DeleteBrk(Buffer); // Удаляем скобки из имени каталога.
				swprintf_s(Text, TEXT_SIZE, L"%s\\%s", CurrentDir, Buffer); // Получаем полный путь к каталогу.
				SetListDir(Text); // Переходим в каталог.
			}
			break;
	}
	return DefListProc(hWnd, Message, wParam, lParam);
}

// Функция обработки сообщений ОС Windows:
LRESULT CALLBACK MainWinProc(HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	switch (Message)
	{
		case WM_CREATE: // Инициализация основного окна и создание на нем элементов управления:
			hWndList = CreateWindowExW(0L, // Нет дополнительных стилей.
									   L"LISTBOX", // Название предустановленного класса.
									   0, // Текст отсутствует.
									   LBS_STANDARD | WS_VISIBLE | WS_CHILD, // Стиль.
									   0, 0, 0, 0, // Размеры.
									   hWnd, // Идентификатор родительского окна.
									   (HMENU)1, // Идентификатор элемента.
									   Instance, // Получение идентификатора приложения.
									   0); // Неиспользуемый указатель.
			// Подмена функций обработки:
			DefListProc = (WNDPROC)GetWindowLong(hWndList, GWL_WNDPROC);
			SetWindowLong(hWndList, GWL_WNDPROC, (LONG)ListProc);
			return 0;

		case WM_PAINT: // Отрисовка полного пути к каталогу или файлу:
			Brush = CreateSolidBrush(RGB(255, 255, 255));
			FillRect(hDC, &ClientArea, Brush);
			TextOut(hDC, 10, ClientArea.bottom - 30, Text, (int)wcslen(Text));
			DeleteObject(Brush);
			break;

		case WM_SIZE: // Обработка изменения размеров основного окна:
			ClientArea.right = LOWORD(lParam);
			ClientArea.bottom = HIWORD(lParam);
			ClientArea.left = 0;
			ClientArea.top = ClientArea.bottom - 40;
			MoveWindow(hWndList, 0, 0, ClientArea.right, ClientArea.bottom - 40, FALSE);
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
	hWndMain = CreateWindowEx(0, L"Laboratory", L"Лабораторная работа 8", WS_TILEDWINDOW, 50, 50, 640, 480, 0, 0, hInstance, 0);

	GetCurrentDirectory(TEXT_SIZE, CurrentDir); // Получение текущего каталога.
	SetListDir(CurrentDir); // Переход к текущему каталогу.

	// Отображение всего созданного на экране:
	ShowWindow(hWndMain, SW_SHOWDEFAULT);
	UpdateWindow(hWndMain);

	hDC = GetDC(hWndMain); // Получаем индентификатор контекста для рисования.
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
