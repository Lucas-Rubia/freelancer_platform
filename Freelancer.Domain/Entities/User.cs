using Freelancers.Domain.Enums;
using Freelancers.Domain.Exceptions;
using Freelancers.Domain.Models;

namespace Freelancers.Domain.Entities;

public class User : BaseModel
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public EUserType UserType { get; set; } = EUserType.Customer;

    public ICollection<Project> Projects { get; set; } = default!;
    public ICollection<Proposal> Proposals { get; set; } = default!;

    private const int PASSWORD_HASH_LENGTH = 60;

    private User(string name, string email, string password, EUserType userType)
    {
        Name = name;
        Email = email;
        Password = password;
        UserType = userType;

        Validate();
    }

    public static User Create(string name, string email, string password, EUserType userType)
    {
        return new User(name, email, password, userType);
    }

    public void UpdateName(string name)
    {
        Name = name;
        UpdatedAt = DateTime.UtcNow;

        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new DomainException("Nome Obrigatório!");

        if (string.IsNullOrWhiteSpace(Email) || !Email.Contains('@'))
            throw new DomainException("O campo não possue um e-mail válido!");

        if (Password.Length != PASSWORD_HASH_LENGTH && (string.IsNullOrWhiteSpace(Password) || (Password.Length < 6 || Password.Length > 20)))
            throw new DomainException("A senha deve conter entre 6 e 20 caracters!");

        if (!Enum.IsDefined(typeof(EUserType), UserType))
            throw new DomainException("Tipo de usuário não é válido!");
    }
}
