using InSharpAssessment.Services.Models.ServiceDTOs;

namespace InSharpAssessment.Services.ServiceManagers.Abstractions
{
    public interface IIndividualService
    {
        //<summary>
        // Get Individual by Id
        // </summary>
        // <param name="id">Individual Id</param>
        // <returns>Individual</returns>
        Task<IndividualServiceDTO> GetIndividualByIdAsync(int id);

        //<summary>
        // Save new Individual
        // </summary>
        // <param name="individual">Individual</param>
        // <returns>Individual Id</returns>
        Task<int> CreateIndividualAsync(IndividualCreateServiceDTO individual);

        //<summary>
        // Update Individual
        // </summary>
        // <param name="individual">Individual</param>
        // <returns>Individual id</returns>
        Task<int> UpdateIndividualAsync(IndividualUpdateServiceDTO individual);

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
        Task<List<IndividualServiceDTO>> GetAllIndividualsAsync();
    }
}
