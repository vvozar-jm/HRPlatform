using API.Mappings.Contracts;
using API.RequestModels;
using Core.Entities;

namespace API.Mappings.Mappers
{
    public class CandidateMapper : ICandidateMapper
    {
        public Candidate MapFromCreateCandidateModel(CreateCandidateModel model)
        {
            return new Candidate
            {
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
                ContactNumber = model.ContactNumber,
                Email = model.Email
            };
        }
    }
}
