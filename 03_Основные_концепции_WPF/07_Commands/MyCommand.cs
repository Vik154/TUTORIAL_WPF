using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _07_Commands;

class MyCommand {

    public static RoutedCommand Delete { get; set; }
    public static RoutedCommand Edit   { get; set; }
    
    static MyCommand() {
        // InputGestureCollection представляет упорядоченную коллекцию объектов InputGesture,
        // которые позволяют с помощью класса KeyGesture задать комбинацию клавиш для вызова команды

        InputGestureCollection inputs = new InputGestureCollection();
        inputs.Add(new KeyGesture(Key.E, ModifierKeys.Control, "Ctrl+E"));
        Edit = new RoutedCommand("Edit", typeof(MyCommand), inputs);
        
        inputs = new InputGestureCollection();
        inputs.Add(new KeyGesture(Key.D, ModifierKeys.Control, "Ctrl+D"));
        Delete = new RoutedCommand("Delete", typeof(MyCommand), inputs);
    }
}
