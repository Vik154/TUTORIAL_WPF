### INotifyPropertyChanged - *Интерфейс представляющий уведомления об изменении свойств.*

*https://learn.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-implement-property-change-notification?view=netframeworkdesktop-4.8* <br>
*https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-7.0* <br>
*Источник 1: https://metanit.com/sharp/wpf/11.2.php* <br>

Чтобы гарантировать, что UI обновляется, когда данные изменяются, нужно реализовать соответствующий интерфейс уведомления об изменениях. Если определяют свойства, к которым будут привязаны данные, тогда нужно реализовать интерфейс INotifyPropertyChanged. Если свойства представляют коллекцию, они должны реализовать INotifyCollectionChanged или наследоваться от класса ObservableCollection<T>, который реализует этот интерфейс. Оба этих интерфейса определяют событие, которое генерируется всякий раз, когда базовые данные изменяются. Любые связанные элементы управления будут автоматически обновлены, когда эти события будут сгенерированы.


<img src="img/Obser.png" align="left" alt="Пример работы данного кода" width="430" height="560">

