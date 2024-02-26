using System.ComponentModel;

namespace CleanArchitecture.Application.Extensions;

public static class EnumExtension
{

    // Bu metot, bir enum değerinin DescriptionAttribute ile belirtilen açıklamasını döndürür.
    // Eğer DescriptionAttribute yoksa boş bir dize döner.
    public static string ToDescriptionString(this Enum value)
    {
        var attribute = value
            .GetType()
            .GetField(value.ToString())
            ?.GetCustomAttributes(typeof(DescriptionAttribute), false)
            .OfType<DescriptionAttribute>()
            .FirstOrDefault();
        return attribute == null ? string.Empty : attribute.Description;
    }


    // Bu metot, bir tamsayı değerini belirtilen enum türüne dönüştürür.
    // Eğer değer belirtilen enum türünde tanımlanmamışsa, varsayılan değeri döndürür.
    public static T Convert<T>(int value)
    {
        return Enum.IsDefined(typeof(T), value) ? (T)Enum.ToObject(typeof(T), value) : default(T);
    }


    // Bu metot, bir tamsayı değerini belirtilen enum türüne dönüştürür.
    // Eğer değer belirtilen enum türünde tanımlanmamışsa, dönüşüm başarısız olur ve false döner.
    public static bool TryConvert<T>(int value, out T result)
    {
        result = default(T);
        if (Enum.IsDefined(typeof(T), value))
        {
            result = (T)Enum.ToObject(typeof(T), value);
            return true;
        }
        return false;

    }
}
