# Туториал по WPF
## Основные источники информации:
1. :earth_asia: WEB:
   + ___---------------Ru Tutorials:---------------___
   + :speech_balloon: https://metanit.com/sharp/wpf/
   + :speech_balloon: https://professorweb.ru/my/WPF/base_WPF/level1/info_WPF.php
   + :speech_balloon: https://intuit.ru/studies/courses?page=1
   + :speech_balloon: https://www.youtube.com/@Shmachilin
   + ___---------------En Tutorials:---------------___
   + :speech_balloon: https://www.youtube.com/@SingletonSean
   + :speech_balloon: https://www.youtube.com/@CSharpDesignPro
3. :notebook: Книги:
   + :blue_book: Мэтью Мак-Дональд "WPF в .NET 4.5 с примерами на C# 5.0 для профессионалов." (*Полезная*)
   + :blue_book: Адам Натан "WPF 4. Подробное руководство." (*Книга понятная только её автору*)
4. :page_with_curl: Документация:
   + :sos: https://learn.microsoft.com/ru-ru/dotnet/desktop/wpf/?view=netdesktop-7.0
   + :sos: https://learn.microsoft.com/ru-ru/dotnet/desktop/wpf/?view=netframeworkdesktop-4.8
   + :sos: https://learn.microsoft.com/ru-ru/search/?terms=wpf&skip=10
   + :sos: https://learn.microsoft.com/ru-ru/windows/apps/desktop/
   + :octocat: https://github.com/microsoft/WPF-Samples/tree/main
5. Исходники стандартных библиотек (быстрый поиск в браузере)
   + https://source.dot.net/ онлайн браузер исходников .NET Core
   + https://referencesource.microsoft.com/ онлайн браузер исходников .NET Framework
6. Для работы:
   + _Расширение для скачивания отдельных папок из GitHub:_ <br>
     https://chrome.google.com/webstore/detail/gitzip-for-github/ffabmkklhbepgcgfonabamgnfafbdlkn/related
   + _Тестирование API:_ <br>
     https://www.postman.com/
   + _Библиотека Майкрософт MVVM Toolkit:_ <br>
      + Пакет: https://www.nuget.org/packages/CommunityToolkit.Mvvm/
      + Документация GIT: https://github.com/MicrosoftDocs/CommunityToolkit/blob/main/docs/mvvm/index.md
      + Документация MSDN: https://learn.microsoft.com/ru-ru/dotnet/communitytoolkit/mvvm/
      + Примеры GIT: https://github.com/CommunityToolkit/MVVM-Samples/tree/master/samples
CommunityToolkit.Mvvm
## Структура проекта:
<details>
   <summary><b><i>1. Основные элементы компоновки:</i></b></summary>
   
   * *[01_Canvas](01_Элементы_компоновки/01_Canvas/Description.md)*
   * *[02_StackPanel](01_Элементы_компоновки/02_StackPanel/Description.md)*
   * *[03_WrapPanel](01_Элементы_компоновки/03_WrapPanel/Description.md)* 
   * *[04_DockPanel](01_Элементы_компоновки/04_DockPanel/Description.md)* 
   * *[05_Grid](01_Элементы_компоновки/05_Grid/Description.md)* 
   * *[06_GridSplitter](01_Элементы_компоновки/06_GridSplitter/Description.md)* 
</details>
<details>
   <summary><b><i>2. Основные элементы управления:</i></b></summary>
   
   * *[01_Button](02_Элементы_управления/01_Button/Description.md)*
   * *[02_CheckBox/RadioButton](02_Элементы_управления/02_CheckBox_and_RadioButton/Description.md)*
   * *[03_ToolTip/Popup](02_Элементы_управления/03_ToolTip_and_Popup/Description.md)*
   * *[04_GroupBox/Expander](02_Элементы_управления/04_GroupBox_and_Expander/Description.md)*
   * *[05_ScrollViewer](02_Элементы_управления/05_ScrollViewer/Description.md)*
   * *[06_TextElements](02_Элементы_управления/06_TextElements/Description.md)*
   * *[07_ListBox](02_Элементы_управления/07_ListBox/Description.md)*
   * *[08_ComboBox](02_Элементы_управления/08_ComboBox/Description.md)*
   * *[09_ListView](02_Элементы_управления/09_ListView/Description.md)*
   * *[10_DataGrid](02_Элементы_управления/10_DataGrid/Description.md)*
</details>
<details>
   <summary><b><i>3. Основные концепции в WPF:</i></b></summary>
   
   * *[Ресурсы](03_Основные_концепции_WPF/01_Resources/Description.md)*
   * *[Стили](03_Основные_концепции_WPF/02_Styles/Description.md)*
   * *[Триггеры](03_Основные_концепции_WPF/03_Triggers/Description.md)*
   * *[Привязка данных](03_Основные_концепции_WPF/04_Binding/Description.md)*
   * *[Свойства зависимостей](03_Основные_концепции_WPF/05_DependencyProperty/Description.md)*
   * *[Маршрутизируемые события](03_Основные_концепции_WPF/06_Events/Description.md)*
   * *[Команды](03_Основные_концепции_WPF/07_Commands/Description.md)*
   * *[Шаблоны элементов управления](03_Основные_концепции_WPF/08_Templates/Description.md)*
   * *[Логическое и визуальное дерево](03_Основные_концепции_WPF/09_LVTrees/Description.md)*
   * *[Шаблоны данных](03_Основные_концепции_WPF/10_DataTemplate/Description.md)*
   * *[Коллекции данных - ObservableCollection](03_Основные_концепции_WPF/11_ObservableCollection/Description.md)*
   * *[Уведомления об изменениях свойств - INotifyPropertyChanged](03_Основные_концепции_WPF/12_INotifyPropertyChanged/Description.md)*
</details>
<details>
   <summary><b><i>4. Проекты:</i></b></summary>

   * *[Проект №1](Projects_Examples/Проект_1/) - по серии уроков (Павла Шмачилина WPF+MVVM) https://www.youtube.com/@Shmachilin* --> <br>
   _Статистика по COVID из института хопкинса, с визуализацией на график и карты._ <br>
   * *[Проект №2](Projects_Examples/Проект_2/) - по серии уроков (Павла Шмачилина WPF+MVVM) https://www.youtube.com/@Shmachilin* --> <br>
     _Асинхронные операции, TPL, в контенксте WPF, на примере реализации шифратора файлов_
   * *[Проект №3](Projects_Examples/Проект_3/) - по серии уроков (Павла Шмачилина WPF+MVVM) https://www.youtube.com/@Shmachilin* --> <br>
     _Работа с EntityFramework и БД в контексте WPF_
   * *[Проект №4](Projects_Examples/Проект_4/) - "Курс по разработке на C# WPF" https://stepik.org/course/108281/promo* --> <br>
     _Разработка менеджера задач на WPF и ASP.NET Core (Если терпение железное)_
   * *[Проект №5](Projects_Examples/Проект_5/) - Работа с EF в контексте WPF и MVVM https://www.youtube.com/@RuslanShishmarev* --> <br>
     _Работа с БД в контексте WPF (😷)_
   * *[Проект №6](Projects_Examples/Проект_6/) - По серии уроков "WPF MVVM Tutorial" https://www.youtube.com/@SingletonSean/playlists* --> <br>
     _Бронирование номеров отеля EF / WPF / MVVM_
   * *[Проект №7](Projects_Examples/Проект_7/) - По серии уроков "Full Stack WPF MVVM" https://www.youtube.com/@SingletonSean/playlists* --> <br>
     _Приложение по торговле акциями в контексте WPF / MVVM / EF_
   * *[Проект №8](Projects_Examples/Проект_8/) - По серии уроков "WPF Contact Book" https://www.youtube.com/@ToskersCorner/playlists* --> <br>
     _Простая записная книга в контексте WPF / MVVM_
   * *[Проект №9](Projects_Examples/Проект_9/) - "WPF - Based Modern Dashboard" https://www.youtube.com/@CSharpDesignPro/playlists* --> <br>
     _Простой проводник в контексте WPF / MVVM с уклоном на UI_
   
</details>


