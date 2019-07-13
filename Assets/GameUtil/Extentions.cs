using System.Linq;
using System.Collections.Generic;

static class Extentions {
    public static string[] ToStrings<T>(this List<T> objectList) {
        return objectList.Select(obj => obj.ToString()).ToArray();
    }
}
