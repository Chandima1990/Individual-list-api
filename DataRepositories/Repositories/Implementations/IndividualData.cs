using InSharpAssessment.DataRepositories.Models.Entities;
using InSharpAssessment.DataRepositories.Repositories.Abstractions;

namespace InSharpAssessment.DataRepositories.Repositories.Implementations
{
    internal class IndividualData : IIndividualData
    {
        public Task<bool> DeleteIndividualAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Individual> GetIndividualByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Individual> SaveIndividualAsync(Individual individual)
        {
            throw new NotImplementedException();
        }

        public Task<Individual> UpdateIndividualAsync(Individual individual)
        {
            throw new NotImplementedException();
        }
    }
}
