using Freelancers.Domain.Enums;
using Freelancers.Domain.Exceptions;
using Freelancers.Domain.Models;

namespace Freelancers.Domain.Entities;

public sealed class Contract : BaseModel
{
    public int Id { get; set; }
    public int ProposalID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public EBaseStatus Status { get; set; } = EBaseStatus.Pending;

    public Proposal Proposal { get; set; } = default!;
    public Review Review { get; set; } = default!;


    private Contract(int proposalID, DateTime startDate, DateTime endDate)
    {
        ProposalID = proposalID;
        StartDate = startDate;
        EndDate = endDate;

        Validate();
    }

    public static Contract Create(int proposalID, DateTime startDate, DateTime endDate)
    {
        return new Contract(proposalID, startDate, endDate);
    }


    private void Validate()
    {
        if (StartDate <= DateTime.UtcNow)
            throw new DomainException("A data não pode ser vazia e tem que ser maior que a data atual");  
        
        if (EndDate <= DateTime.UtcNow && StartDate <= EndDate)
            throw new DomainException("A data não pode ser vazia e não pode ser igual a Data Inicial");

        if (!Enum.IsDefined(typeof(EBaseStatus), Status))
            throw new DomainException("Status indefinido, é preciso defini-lo como Accept, Pending ou Canceled");
    }
}
