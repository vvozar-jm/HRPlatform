using API.MapperServices.Contracts;
using API.RequestModels;
using Core.Entities;

namespace API.MapperServices.Mappers
{
    public class CandidateServiceMapper : ICandidateServiceMapper
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
