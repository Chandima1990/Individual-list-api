using InSharpAssessment.DataRepositories.Models.DTOs;

namespace InSharpAssessment.DataRepositories.DataManagers.Abstractions
{
    /// <summary>
    /// Abstraction for Individual Data, 
    /// All the CURD operations handle with this interface
    /// </summary>
    public interface IIndividualData
    {

        //<summary>
        // Get Individual by Id
        // </summary>
        // <param name="id">Individual Id</param>
        // <returns>Individual</returns>
        Task<IndividualDataDTO> GetIndividualByIdAsync(int id);

        //<summary>
        // Save new Individual
        // </summary>
        // <param name="individual">Individual</param>
        // <returns>Individual Id</returns>
        Task<int> CreateIndividualAsync(IndividualDataDTO individual);

        //<summary>
        // Update Individual
        // </summary>
        // <param name="individual">Individual</param>
        // <returns>Individual Id</returns>
        Task<int> UpdateIndividualAsync(IndividualDataDTO individual);


        //<summary>
        // Delete Individual
        // </summary>
        // <param name="id">Individual Id</param>
        // <returns>bool</returns>
        Task<bool> DeleteIndividualAsync(int id);

        //<summary>
        // Get All Individuals 
        // </summary>
        // <returns>Individuals</returns>
        Task<List<IndividualDataDTO>> GetAllIndividualsAsync();
    }
}
