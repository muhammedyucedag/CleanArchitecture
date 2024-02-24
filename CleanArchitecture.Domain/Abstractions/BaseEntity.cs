namespace CleanArchitecture.Domain.Abstractions;

//abstract yaparak bir clasa bağımlı kıldık
public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}
