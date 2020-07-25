						Кнопки и переключатели

1. Создать в главном окне элементы управления следующих типов:
	BS_PUSHBUTTON, 
	BS_DEFPUSHBUTTON,
	BS_CHECKBOX,
	BS_AUTOCHECKBOX,
	BS_RADIOBUTTON,
	BS_AUTORADIOBUTTON,
	BS_3STATE,
	BS_AUTO3STATE,
	BS_GROUPBOX,
	BS_USERBUTTON,
	BS_OWNERDRAW.
2. Отслеживать сообщения от этих элементов и выводить в окно информацию из сообщений
	в виде, предложенном образцом.

							Рекомендации

1. Чтобы получить рабочую область окна:
	static RECT rect;
	...
	GetClientRect(hWnd, (LPRECT)&rect);
2. При создании элемента управления функцией CreateWindow 3-й параметр:
		WS_CHILD | WS_VISIBLE | <стиль кнопки>,
	а 9-й - индекс элемента:
		(HMENU)i
3. Чтобы текст заголовка отрисовывался на фоне окна, нужно установить прозрачность:
		SetBKMode(hdc, TRANSPARENT);
