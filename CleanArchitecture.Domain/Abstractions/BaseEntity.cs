namespace CleanArchitecture.Domain.Abstractions;

//abstract yaparak bir clasa bağımlı kıldık
public abstract class BaseEntity
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}
