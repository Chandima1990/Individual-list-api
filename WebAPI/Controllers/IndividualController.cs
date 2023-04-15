using InSharpAssessment.Services.Models.ServiceDTOs;
using InSharpAssessment.Services.ServiceManagers.Abstractions;
using InSharpAssessment.WebAPI.Models.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace InSharpAssessment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualController : ControllerBase
    {
        private readonly IIndividualService individualService;

        public IndividualController(IIndividualService individualService)
        {
            this.individualService = individualService;
        }

        /// <summary>
        /// Get all individuals 
        /// </summary>
        /// <returns>Individual List</returns>
        /// <response code="200">Returns the individual's list</response>
        /// <response code="500">Returns server error when an unhandled exception thrown or any other server error</response>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<IndividualVM>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync()
        {
            var individuals = await individualService
                .GetAllIndividualsAsync();

            return Ok(individuals);
        }

        /// <summary>
        /// Get individual by Id
        /// </summary>
        /// <returns>Individual object</returns>
        /// <response code="200">Returns an individual object</response>
        /// <response code="400">Returns bad request response when the request does not have required format or data</response>
        /// <response code="404">Returns not found when the given id does not return any record</response>
        /// <response code="500">Returns server error when an unhandled exception thrown or any other server error</response>
        [HttpGet("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var individual = await individualService.GetIndividualByIdAsync(id);
            return Ok(individual);
        }

        /// <summary>
        /// Create new Individual object
        /// </summary>
        /// <returns>Created individual id</returns>
        /// <response code="201">Returns the id of created record</response>
        /// <response code="400">Returns bad request response when the request does not have required format or data</response>
        /// <response code="409">Returns conflict when the record already exist or anyother conflict</response>
        /// <response code="500">Returns server error when an unhandled exception thrown or any other server error</response>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] IndividualCreateVM individualFormData)
        {
            var individual = individualFormData
                .Adapt<IndividualCreateServiceDTO>();

            var individualId = await individualService
                .CreateIndividualAsync(individual);

            return Ok(individualId);
        }

        /// <summary>
        /// Update given Individual object
        /// </summary>
        /// <returns>Updated individual id</returns>
        /// <response code="201">Returns the id of created record</response>
        /// <response code="400">Returns bad request response when the request does not have required format or data</response>
        /// <response code="404">Returns not found when the given id does not return any record</response>
        /// <response code="409">Returns conflict when the record already exist or anyother conflict</response>
        /// <response code="500">Returns server error when an unhandled exception thrown or any other server error</response>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] IndividualUpdateVM individualFormData)
        {

            var individual = individualFormData
                .Adapt<IndividualUpdateServiceDTO>();

            var updatedIndividualId = await individualService
                .UpdateIndividualAsync(individual);
            return Ok(updatedIndividualId);
        }

        /// <summary>
        /// Delete given Individual object
        /// </summary>
        /// <returns>isDeleted boolean</returns>
        /// <response code="200">Returns true if deleted record</response>
        /// <response code="400">Returns bad request response when the request does not have required format or data</response>
        /// <response code="404">Returns not found when the given id does not return any record</response>
        /// <response code="500">Returns server error when an unhandled exception thrown or any other server error</response>
        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var isDeleted = await individualService.DeleteIndividualAsync(id);
            return Ok(isDeleted);
        }
    }
}
