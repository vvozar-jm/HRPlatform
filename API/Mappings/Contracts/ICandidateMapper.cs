using API.RequestModels;
using Core.Entities;

namespace API.Mappings.Contracts
{
    public interface ICandidateMapper
    {
        Candidate MapFromCreateCandidateModel(CreateCandidateModel model);
    }
}
