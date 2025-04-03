using Freelancers.Domain.Exceptions;
using Freelancers.Domain.Models;

namespace Freelancers.Domain.Entities;

public class Review : BaseModel
{
    public int Id { get; set; }
    public int ContractID { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;

    public Contract Contract { get; set; } = default!;

    private Review(int contractID, int rating, string comment)
    {
        ContractID = contractID;
        Rating = rating;
        Comment = comment;

        Validate();
    }

    public static Review Create(int contractID, int rating, string comment)
    {
        return new Review(contractID, rating, comment);
    }

    public void UpdateReview(int rating, string comment){
        Rating = rating;
        Comment = comment;
        UpdatedAt = DateTime.Now;

        Validate();
    }


    private void Validate()
    {
        if (Rating == 0)
            throw new DomainException("Compo Obrigatorio");

        if (string.IsNullOrEmpty(Comment))
            throw new DomainException("Compo Obrigatorio");
    }

}
