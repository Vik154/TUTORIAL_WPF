namespace System;


static class RandomExtensions {
    public static T NextItemExtension<T>(this Random random, params T[] items) =>
        items[random.Next(items.Length)];
}
