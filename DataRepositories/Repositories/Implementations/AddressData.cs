using InSharpAssessment.DataRepositories.Models.Entities;
using InSharpAssessment.DataRepositories.Repositories.Abstractions;

namespace InSharpAssessment.DataRepositories.Repositories.Implementations
{
    internal class AddressData : IAddressData
    {
        public Task<Address> GetAddressByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
