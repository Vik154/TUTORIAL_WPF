using System.Globalization;
using System.Windows.Data;


namespace StartUpMVVM.Infrastructure.Converters;


internal class ToArray : MultiConverter {

    public override object Convert(object[] vv, Type t, object p, CultureInfo c) {
        var collection = new CompositeCollection();
        foreach (var value in vv)
            collection.Add(value);
        return collection;
    }

    //public override object[] ConvertBack(object v, Type[] tt, object p, CultureInfo c) => v as object[];
}
