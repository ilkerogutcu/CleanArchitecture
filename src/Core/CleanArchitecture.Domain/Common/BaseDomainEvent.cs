namespace CleanArchitecture.Domain.Common;

public abstract class BaseDomainEvent : INotification
{ 
    public Guid Id { get; }
    public bool IsPublished { get; set; }
    public DateTime DateOccurred { get; }

    protected BaseDomainEvent()
    {
        Id = Guid.NewGuid();
        DateOccurred = DateTime.UtcNow;
    }
}