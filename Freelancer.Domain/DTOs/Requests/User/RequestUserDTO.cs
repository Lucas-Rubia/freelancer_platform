using Freelancers.Domain.Enums;

namespace Freelancers.Domain.DTOs.Requests.User;

public class RequestUserDTO
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public EUserType UserType { get; set; } = EUserType.Customer;
}
