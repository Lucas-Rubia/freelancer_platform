using Freelancers.Domain.Enums;

namespace Freelancers.Domain.DTOs.Responses.User;

public class ResponseUserDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    public EUserType UserType { get; set; } = EUserType.Customer;
}
