NetSdkPack
==========


Описание
--------

Проект кросс-платформенного NuGet-пакета для демонстрации работы с неуправляемым кодом на разных системах.
Разрабатывался с учётом перехода с .NET Framework на .NET, поэтому поддерживает несколько целевых платформ.
Пакет спроектирован таким образом, что для полного перехода со старых сборок достаточно удалить net4xx и
ссылку на файл сборки MSBuild из проектного файла, а также удалить класс LegacyPInvoke, отвечающий за старый
платформозависимый механизм подключения динамических библиотек.


Сборка
------

Для сборки необходимо выполнить команду в корневом каталоге:

    dotnet pack

Версия пакета задаётся в проектном файле и параллельно влияет на версии сборки и файла сборки, если последние не указаны.
Если при сборке необходимо переопределить версию, то можно воспользоваться командой:

    dotnet pack -p:PackageVersion=1.0.0


Visual Studio Code
------------------

Дополнительно проект содержит .vscode для упрощения сборки на других платформах.