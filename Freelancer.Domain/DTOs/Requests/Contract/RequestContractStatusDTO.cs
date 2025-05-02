using Freelancers.Domain.Enums;

namespace Freelancers.Domain.DTOs.Requests.Contract;

public class RequestContractStatusDTO
{
    public int ContractID { get; set; }
    public EBaseStatus Status { get; set; }
}
