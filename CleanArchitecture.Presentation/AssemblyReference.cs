using System.Reflection;

namespace CleanArchitecture.Presentation
{
    //Bu kod, Assembly sınıfının referansını oluşturarak, projede kullanılan Assembly özelliklerine erişimi sağlar.
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(Assembly).Assembly;
    }
}
