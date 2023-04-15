using InSharpAssessment.Common.Exceptions;
using InSharpAssessment.DataRepositories.Context;
using InSharpAssessment.DataRepositories.DataManagers.Abstractions;
using InSharpAssessment.DataRepositories.Models.DTOs;
using InSharpAssessment.DataRepositories.Models.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace InSharpAssessment.DataRepositories.DataManagers.Implementations
{
    internal class IndividualData : IIndividualData
    {
        //db context instance 
        private readonly ApplicationDBContext dbContext;

        public IndividualData(ApplicationDBContext dBContext)
        {
            dbContext = dBContext;
        }
        public Task<bool> DeleteIndividualAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IndividualDataDTO> GetIndividualByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateIndividualAsync(IndividualDataDTO individualDto)
        {
            // create new individual
            try
            {
                var individual = individualDto.Adapt<Individual>();

                var individualExist = dbContext.Individuals.Select(i =>
                    i.PhoneNumber == individual.PhoneNumber &&
                    i.FirstName == individual.FirstName &&
                    i.LastName == individual.LastName);

                // already added
                if (individualExist.Any())
                {
                    throw new ConflictException(HttpStatusCode.Conflict,
                        "The individual already exist in the system");
                }

                await dbContext.Individuals.AddAsync(individual);
                await dbContext.SaveChangesAsync();

                return individual.Id;

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

        public Task<IndividualDataDTO> UpdateIndividualAsync(IndividualDataDTO individual)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IndividualDataDTO>> GetAllIndividualsAsync()
        {
            // get all individuals
            try
            {
                var individuals = await dbContext.Individuals
                    .ToListAsync();

                return individuals.Adapt<List<IndividualDataDTO>>();
            }
            catch (Exception ex)
            {
                // unhandled server error
                // TODO logger
                throw new ServerErrorException(ex);
            }
        }
    }
}
