using InSharpAssessment.Services.Models.ServiceDTOs;
using InSharpAssessment.Services.ServiceManagers.Abstractions;

namespace InSharpAssessment.Services.ServiceManagers.Implementations
{
    public class AddressService : IAddressService
    {
        public async Task<int> CreateAddressAsync(AddressServiceDTO address)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAddressAsync(AddressServiceDTO address)
        {
            throw new NotImplementedException();
        }

        public async Task<AddressServiceDTO> GetAddressByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AddressServiceDTO>> GetAllAddressesForIndividualAsync(int individualId)
        {
            throw new NotImplementedException();
        }

        public async Task<AddressServiceDTO> UpdateAddressAsync(AddressServiceDTO address)
        {
            throw new NotImplementedException();
        }
    }
}
