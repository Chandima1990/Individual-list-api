using InSharpAssessment.DataRepositories.Models.Entities;

namespace InSharpAssessment.DataRepositories.Repositories.Abstractions
{
    internal interface IAddressData
    {
        //<summary>
        // Get Address by Id
        // </summary>
        // <param name="id">Address Id</param>
        // <returns>Address</returns>
        Task<Address> GetAddressByIdAsync(int id);
    }
}
