namespace Domain.Entities.Abstractions;
public abstract class BaseEntity
{
    public string Id { get; set; }
    public BaseEntity()
    {
        Id = Guid.NewGuid().ToString();
    }

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}