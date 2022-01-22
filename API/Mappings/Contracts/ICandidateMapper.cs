using API.RequestModels;
using API.ResponseModels;
using Core.Entities;

namespace API.Mappings.Contracts
{
    public interface ICandidateMapper
    {
        Candidate MapFromCreateCandidateModel(CreateCandidateModel model);
        CandidateViewModel MapToCandidateViewModel(Candidate model);
    }
}
