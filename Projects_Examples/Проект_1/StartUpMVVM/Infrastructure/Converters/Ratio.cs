﻿using System.Globalization;
using System.Windows.Markup;


namespace StartUpMVVM.Infrastructure.Converters;


[MarkupExtensionReturnType(typeof(Ratio))]
internal class Ratio : Converter {

    [ConstructorArgument("K")]
    public double K { get; set; } = 1;

    public Ratio(double k) => K = k;

    public Ratio() { }

    public override object? Convert(object value, Type t, object p, CultureInfo c) {
        if (value is null)
            return null;
        var x = System.Convert.ToDouble(value, c);

        return x * K;
    }

    public override object? ConvertBack(object value, Type t, object p, CultureInfo c) {
        if (value is null || string.IsNullOrEmpty(value.ToString()))
            return null;
        var x = System.Convert.ToDouble(value, c);
        
        return x / K;
    }
}
