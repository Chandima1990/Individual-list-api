using InSharpAssessment.Services.Models.ServiceDTOs;
using InSharpAssessment.Services.ServiceManagers.Abstractions;

namespace InSharpAssessment.Services.ServiceManagers.Implementations
{
    public class IndividualService : IIndividualService
    {
        public async Task<bool> DeleteIndividualAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateIndividualAsync(IndividualCreateServiceDTO individual)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IndividualServiceDTO>> GetAllIndividualsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IndividualServiceDTO> GetIndividualByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateIndividualAsync(IndividualUpdateServiceDTO individual)
        {
            throw new NotImplementedException();
        }
    }
}
