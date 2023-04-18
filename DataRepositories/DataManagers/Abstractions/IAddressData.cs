using InSharpAssessment.DataRepositories.Models.DTOs;

namespace InSharpAssessment.DataRepositories.DataManagers.Abstractions
{
    /// <summary>
    /// As the addrresses are not being accessed directly from the application
    /// These method might not be used
    /// </summary>
    public interface IAddressData
    {
        //<summary>
        // Get Address by Id
        // </summary>
        // <param name="id">Address Id</param>
        // <returns>Address</returns>
        Task<AddressDataDTO> GetAddressByIdAsync(int id);

        // <summary>
        // Create Address for Individual
        // </summary>
        // <param name="address">Address</param>
        // <returns>Address Id</returns>
        Task<int> CreateAddressAsync(AddressDataDTO address);

        // <summary>
        // Update Address for Individual
        // </summary>
        // <param name="address">Address</param>
        // <returns>Address</returns>
        Task<AddressDataDTO> UpdateAddressAsync(AddressDataDTO address);

        // <summary>
        // Delete Address for Individual
        // </summary>
        // <param name="address">Address</param>
        // <returns>Address Deleted</returns>
        Task<bool> DeleteAddressAsync(AddressDataDTO address);

        // <summary>
        // Get All Addresses for Individual
        // </summary>
        // <param name="individualId">Individual Id</param>
        // <returns>Address</returns>
        Task<List<AddressDataDTO>> GetAllAddressesForIndividualAsync(int individualId);

    }
}
