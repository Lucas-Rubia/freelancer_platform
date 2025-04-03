using Freelancers.Domain.Exceptions;
using Freelancers.Domain.Models;

namespace Freelancers.Domain.Entities;

public class Project : BaseModel
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime DeadLine { get; set; } = default!;
    public decimal Bugdet { get; set; } = default!;
    public int UserId { get; set; }

    public User User { get; set; } = default!;

    public ICollection<Proposal> Proposals { get; set; } = default!;

    //private Project() { }
    private Project(string title, string description, DateTime deadLine, decimal bugdet, int userId)
    {
        Title = title;
        Description = description;
        DeadLine = deadLine;
        Bugdet = bugdet;
        UserId = userId;

        Validate();
    }

    public static Project Create(string title, string description, DateTime deadLine, decimal bugdet, int userId)
    {
        return new Project(title, description, deadLine, bugdet,userId);
    }


   public void UpdateProject(string title, string description, DateTime deadline, decimal bugdet)
    {
        Title = title;
        Description = description;
        DeadLine = deadline;
        Bugdet = bugdet;
        UpdatedAt = DateTime.UtcNow;

        Validate();
    }   

    private void Validate()
    {
        if (string.IsNullOrEmpty(Title))
            throw new DomainException("Titulo não pode ser vazio");

        if (string.IsNullOrEmpty(Description))
            throw new DomainException("Descrição não pode ser vazia");

        if (DeadLine > DateTime.UtcNow)
            throw new DomainException("A DeadLine não pode ser vazia");

        if (decimal.IsNegative(Bugdet) || Bugdet == 0)
            throw new DomainException("O Bugdet deve não pode ser vazio e deve conter um valor acima de 0");
    }
    
}
