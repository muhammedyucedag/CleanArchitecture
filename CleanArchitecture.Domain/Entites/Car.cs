using CleanArchitecture.Domain.Entites.Common;

namespace CleanArchitecture.Domain.Entites;

//sealed olarak işaretlediğimiz için bu sınıftan başka bir sınıf oluşturulamaz veya miras alınamaz
public sealed class Car : BaseEntity
{
    public string Name { get; set; }
    public string Model { get; set; }
    public int EnginePower { get; set; }
}
