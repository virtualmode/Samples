			Отображение текущего каталога

1. Отображает содержимое текущего каталога в виде списка,
содержащего все файлы, каталоги и выход на каталог верхнего
уровня. Текущий каталог показан в отдельной строке.
2. Двойной щелчок по элементу списка приводит:
- для [..] - выход на верхний уровень,
- для имени каталога - переход к этому каталогу,
- для файла - добавление имени файла в строку текущего каталога.

			Рекомендации

1.Для заполнения списка воспользоваться сообщением LB_DIR.
2. Получать значение текущего каталога функцией GetCurrentDirectory,
а для установки текущего каталога использовать функцию
SetCurrentDirectory.
