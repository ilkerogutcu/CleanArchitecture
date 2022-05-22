namespace CleanArchitecture.Domain.Common;

public interface IAuditableEntity
{
    public string CreatedBy { get; set; } 
    public DateTime CreatedDate { get; set; } 
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}