using InSharpAssessment.Common.Exceptions;
using InSharpAssessment.DataRepositories.DataManagers.Abstractions;
using InSharpAssessment.DataRepositories.Models.DTOs;
using InSharpAssessment.Services.Models.ServiceDTOs;
using InSharpAssessment.Services.ServiceManagers.Abstractions;
using Mapster;

namespace InSharpAssessment.Services.ServiceManagers.Implementations
{
    public class IndividualService : IIndividualService
    {
        private readonly IIndividualData _individualData;

        public IndividualService(IIndividualData individualData)
        {
            _individualData = individualData;
        }

        public async Task<bool> DeleteIndividualAsync(int id)
        {
            try
            {
                var result = await _individualData
                    .DeleteIndividualAsync(id);

                return result;
            }
            catch (ApiException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ex);
            }
        }

        public async Task<int> CreateIndividualAsync(IndividualCreateServiceDTO individualDto)
        {
            try
            {
                var individual = individualDto.Adapt<IndividualDataDTO>();

                var result = await _individualData
                    .CreateIndividualAsync(individual);

                return result;
            }
            catch (ApiException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ex);
            }
        }

        public async Task<PagedServiceDTO<IndividualServiceDTO>> GetAllIndividualsAsync(int page, int pageSize)
        {
            try
            {
                var results = await _individualData
                    .GetAllIndividualsAsync(page, pageSize);

                return results.Adapt<PagedServiceDTO<IndividualServiceDTO>>();
            }
            catch (ApiException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ex);
            }
        }

        public async Task<IndividualServiceDTO> GetIndividualByIdAsync(int id)
        {
            try
            {
                var individual = await _individualData
                    .GetIndividualByIdAsync(id);

                return individual.Adapt<IndividualServiceDTO>();
            }
            catch (ApiException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ex);
            }
        }

        public async Task<int> UpdateIndividualAsync(IndividualUpdateServiceDTO individualDto)
        {
            try
            {
                var individual = individualDto.Adapt<IndividualDataDTO>();

                var result = await _individualData
                    .UpdateIndividualAsync(individual);

                return result;
            }
            catch (ApiException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ex);
            }
        }
    }
}
