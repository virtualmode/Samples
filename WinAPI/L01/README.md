Создать главное окно - всплывающее, а также одно дочернее и два всплывающих 
окна: одно с родителем, другое - без. Проанализировать взаимное перемещение 
окон, их минимизацию и максимизацию.

						Рекомендации

Позиционирование и размеры окон указывать относительно размеров экрана, которые
можно получить через функцию GetSystemMetrics:

GetSystemMetrics(SM_CXSCREEN) - горизонтальный размер
GetSystemMetrics(SM_CYSCREEN) - вертикальный размер