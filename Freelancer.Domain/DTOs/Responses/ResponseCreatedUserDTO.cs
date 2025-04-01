using Freelancers.Domain.Enums;

namespace Freelancers.Domain.DTOs.Responses;

public class ResponseCreatedUserDTO
{
    public string Name { get; set; } = default!;
    public EUserType UserType { get; set; }
}
