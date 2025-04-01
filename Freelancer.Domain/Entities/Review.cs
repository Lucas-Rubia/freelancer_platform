using Freelancers.Domain.Models;

namespace Freelancers.Domain.Entities;

public class Review : BaseModel
{
    public int Id { get; set; }
    public int ContractID { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;

    public Contract Contract { get; set; } = default!;
}
