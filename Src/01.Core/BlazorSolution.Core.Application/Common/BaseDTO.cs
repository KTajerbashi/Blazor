namespace BlazorSolution.Core.Application.Common;

public abstract class BaseDTO<TId>
{
    public TId Id { get; set; }
    public Guid Key { get; set; }
    public DateTime CreatedDate { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTime? UpdateDate { get; set; }
    public long? UpdatedByUserId { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
public abstract class BaseDTO : BaseDTO<long>
{

}