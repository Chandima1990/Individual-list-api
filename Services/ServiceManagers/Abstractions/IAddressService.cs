using InSharpAssessment.Services.Models.ServiceDTOs;

namespace InSharpAssessment.Services.ServiceManagers.Abstractions
{
    public interface IAddressService
    {
        //<summary>
        // Get Address by Id
        // </summary>
        // <param name="id">Address Id</param>
        // <returns>Address</returns>
        Task<AddressServiceDTO> GetAddressByIdAsync(int id);

        // <summary>
        // Create Address for Individual
        // </summary>
        // <param name="address">Address</param>
        // <returns>Address Id</returns>
        Task<int> CreateAddressAsync(AddressServiceDTO address);

        // <summary>
        // Update Address for Individual
        // </summary>
        // <param name="address">Address</param>
        // <returns>Address</returns>
        Task<AddressServiceDTO> UpdateAddressAsync(AddressServiceDTO address);

        // <summary>
        // Delete Address for Individual
        // </summary>
        // <param name="address">Address</param>
        // <returns>Address Deleted</returns>
        Task<bool> DeleteAddressAsync(AddressServiceDTO address);

        // <summary>
        // Get All Addresses for Individual
        // </summary>
        // <param name="individualId">Individual Id</param>
        // <returns>Address</returns>
        Task<List<AddressServiceDTO>> GetAllAddressesForIndividualAsync(int individualId);
    }
}
