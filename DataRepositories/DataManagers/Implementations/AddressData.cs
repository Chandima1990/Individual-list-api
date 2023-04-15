using InSharpAssessment.Common.Exceptions;
using InSharpAssessment.DataRepositories.Context;
using InSharpAssessment.DataRepositories.DataManagers.Abstractions;
using InSharpAssessment.DataRepositories.Models.DTOs;
using InSharpAssessment.DataRepositories.Models.Entities;
using Mapster;
using System.Net;

namespace InSharpAssessment.DataRepositories.DataManagers.Implementations
{
    public class AddressData : IAddressData
    {
        //db context instance 
        private readonly ApplicationDBContext dbContext;

        public AddressData(ApplicationDBContext dBContext)
        {
            dbContext = dBContext;
        }

        public async Task<int> CreateAddressAsync(AddressDataDTO addressDto)
        {
            // create new address for individual
            try
            {
                var address = addressDto.Adapt<Address>();

                var addressExist = dbContext.Addresses.Select(a =>
                    a.IndividualId == address.IndividualId &&
                    a.City == address.City &&
                    a.Street == address.Street &&
                    a.Country == address.Country);

                // already added
                if (addressExist.Any())
                {
                    throw new ConflictException(HttpStatusCode.Conflict,
                        "The address is already added for this Individual");
                }

                await dbContext.Addresses.AddAsync(address);
                await dbContext.SaveChangesAsync();

                return address.Id;

            }
            catch (ApiException)
            {
                //TODO logger
                throw;
            }
            catch (Exception ex)
            {
                // unhandled server error
                // TODO logger
                throw new ServerErrorException(ex);
            }
        }

        public async Task<bool> DeleteAddressAsync(AddressDataDTO addressDto)
        {

            // delete address by given id
            throw new NotImplementedException();

        }

        public async Task<AddressDataDTO> GetAddressByIdAsync(int id)
        {

            // Get address by given address id

            throw new NotImplementedException();

        }

        public async Task<List<AddressDataDTO>> GetAllAddressesForIndividualAsync(int individualId)
        {
            throw new NotImplementedException();
        }

        public async Task<AddressDataDTO> UpdateAddressAsync(AddressDataDTO addressDto)
        {
            throw new NotImplementedException();
        }
    }
}
