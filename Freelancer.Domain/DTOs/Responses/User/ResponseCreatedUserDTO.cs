using Freelancers.Domain.Enums;

namespace Freelancers.Domain.DTOs.Responses.User;

public class ResponseCreatedUserDTO
{
    public string Name { get; set; } = default!;
    public EUserType UserType { get; set; }
}
