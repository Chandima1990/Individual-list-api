using InSharpAssessment.DataRepositories.Models.Entities;

namespace InSharpAssessment.DataRepositories.Repositories.Abstractions
{
    /// <summary>
    /// Abstraction for Individual Data, 
    /// All the CURD operations handle with this interface
    /// </summary>
    internal interface IIndividualData
    {

        //<summary>
        // Get Individual by Id
        // </summary>
        // <param name="id">Individual Id</param>
        // <returns>Individual</returns>
        Task<Individual> GetIndividualByIdAsync(int id);

        //<summary>
        // Save new Individual
        // </summary>
        // <param name="individual">Individual</param>
        // <returns>Individual</returns>
        Task<Individual> SaveIndividualAsync(Individual individual);

        //<summary>
        // Update Individual
        // </summary>
        // <param name="individual">Individual</param>
        // <returns>Individual</returns>
        Task<Individual> UpdateIndividualAsync(Individual individual);


        //<summary>
        // Delete Individual
        // </summary>
        // <param name="id">Individual Id</param>
        // <returns>bool</returns>
        Task<bool> DeleteIndividualAsync(int id);
    }
}
