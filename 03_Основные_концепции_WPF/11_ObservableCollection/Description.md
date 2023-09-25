### Концепция шаблонов данных - *представляет механизм для настройки отображения объектов заданного типа.* 

*MSDN: https://learn.microsoft.com/ru-ru/dotnet/api/system.collections.objectmodel.observablecollection-1?view=net-7.0* <br>
*Источник 1: https://metanit.com/sharp/wpf/14.2.php* <br>
*Источник 2: https://metanit.com/sharp/tutorial/4.13.php* <br>

ObservableCollection — это класс коллекции, которая позволяет известить внешние объекты о том, что коллекция была изменена и позволяет подписаться на уведомления об изменениях.

___Уведомление об измении коллекции:___ <br>
Класс ObservableCollection определяет событие CollectionChanged, подписавшись на которое, мы можем обработать любые изменения коллекции. Данное событие представляет делегат NotifyCollectionChangedEventHandler:
~~~C#
void NotifyCollectionChangedEventHandler(object? sender, NotifyCollectionChangedEventArgs e);
~~~

___NotifyCollectionChangedEventArgs___ - хранит всю информацию о событии. В частности, его свойство Action позволяет узнать характер изменений. Оно хранит одно из значений из перечисления NotifyCollectionChangedAction: <br>
* NotifyCollectionChangedAction.Add: добавление
* NotifyCollectionChangedAction.Remove: удаление
* NotifyCollectionChangedAction.Replace: замена
* NotifyCollectionChangedAction.Move: перемещение объекта внутри коллекции на новую позицию
* NotifyCollectionChangedAction.Reset: сброс содержимого коллекции (например, при ее очистке с помощью метода Clear()) <br>

Кроме того, свойства NewItems и OldItems позволяют получить соответственно добавленные и удаленные объекты. Таким образом, мы получаем полный контроль над обработкой добавления, удаления и замены объектов в коллекции. <br>

<img src="img/Data1.png" align="left" alt="Пример работы данного кода" width="300" height="250">
