using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Common;

public abstract class BaseEntity<TKey>
{
    [Key] public TKey Id { get; set; }
    public ICollection<BaseDomainEvent> DomainEvents { get; private set; } = new List<BaseDomainEvent>();

    public void AddDomainEvent(BaseDomainEvent domainEvent)
    {
        DomainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(BaseDomainEvent domainEvent)
    {
        DomainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        DomainEvents.Clear();
    }


    public bool IsTransient()
    {
        return Id != null && Id.Equals(default(TKey));
    }

    public override bool Equals(object? obj)
    {
        if (!(obj is BaseEntity<TKey> entity))
            return false;

        if (ReferenceEquals(this, entity))
            return true;

        if (IsTransient() || entity.IsTransient())
            return false;

        var item = entity;
        if (item.IsTransient() || IsTransient())
        {
            return false;
        }

        return Equals(obj);
    }
}