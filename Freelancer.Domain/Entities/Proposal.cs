using Freelancers.Domain.Enums;
using Freelancers.Domain.Exceptions;
using Freelancers.Domain.Models;

namespace Freelancers.Domain.Entities;

public class Proposal : BaseModel
{
    public int Id { get; set; }
    public int ProjectID { get; set; }
    public int FreelancerId { get; set; }
    public decimal ProposedValue { get; set; }
    public string Message { get; set; } = default!;
    public EBaseStatus Status { get; set; } = EBaseStatus.Pending;

    public User Freelancer { get; set; } = default!;
    public Project Project { get; set; } = default!;
    public Contract Contract { get; set; } = default!;

    private Proposal(int projectID, int freelancerId, decimal proposedValue, string message, EBaseStatus status)
    {
        ProjectID = projectID;
        FreelancerId = freelancerId;
        ProposedValue = proposedValue;
        Message = message;
        Status = status;

        Validate();
    }

    public static Proposal Create(int projectID, int freelancerId, decimal proposedValue, string message, EBaseStatus status)
    {
        return new Proposal(projectID, freelancerId, proposedValue, message, status);
    }

    public void UpdateProposal(decimal proposalValue, string message, EBaseStatus status)
    {
        ProposedValue = proposalValue;
        Message = message;
        Status = status;
        UpdatedAt = DateTime.UtcNow;

        Validate();
    }

    private void Validate()
    {
        if (decimal.IsNegative(ProposedValue) || ProposedValue <= 0)
            throw new DomainException("A proposta de negócio deve não pode ser vazio e deve conter um valor acima de 0");

        if (string.IsNullOrEmpty(Message))
            throw new DomainException("O campo deve conter uma mensagem");

        if (!Enum.IsDefined(typeof(EBaseStatus), Status))
            throw new DomainException("Status indefinido, é preciso defini-lo como Accept, Pending ou Canceled");
    }
}
