using API.RequestModels;
using Core.Entities;

namespace API.MapperServices.Contracts
{
    public interface ICandidateServiceMapper
    {
        Candidate MapFromCreateCandidateModel(CreateCandidateModel model);
    }
}
