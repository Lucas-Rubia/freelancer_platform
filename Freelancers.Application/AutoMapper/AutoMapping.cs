using AutoMapper;
using Freelancers.Domain.DTOs.Responses.Contract;
using Freelancers.Domain.DTOs.Responses.Projects;
using Freelancers.Domain.DTOs.Responses.Proposal;
using Freelancers.Domain.DTOs.Responses.Review;
using Freelancers.Domain.DTOs.Responses.User;
using Freelancers.Domain.Entities;

namespace Freelancers.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        //CreateMap<RequestProjectDTO, Project>();
    }

    private void EntityToResponse()
    {
        CreateMap<Project, ResponseProjectsDTO>();
        CreateMap<Project, ResponseCreateProjectDTO>();
        CreateMap<Proposal, ResponseProposalDTO>();
        CreateMap<Proposal, ResponseCreatedProposalDTO>();
        CreateMap<Review, ResponseReviewDTO>();
        CreateMap<Review, ResponseCreateReviewDTO>();
        CreateMap<Contract, ResponseContractDTO>();
        CreateMap<User, ResponseUserDTO>();
        CreateMap<User, ResponseCreatedUserDTO>();
        CreateMap<Proposal, ResponseProposalStatusDTO>();
        CreateMap<Proposal, ResponseProposalInformationDTO>();
        CreateMap<Project, ResponseProjectInformationDTO>();
    }
}
