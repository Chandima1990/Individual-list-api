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
    public class IndividualData : IIndividualData
    {
        //db context instance 
        private readonly ApplicationDBContext dbContext;

        public IndividualData(ApplicationDBContext dBContext)
        {
            dbContext = dBContext;
        }

        public async Task<bool> DeleteIndividualAsync(int id)
        {
            // get individual by id
            try
            {
                var individual = await dbContext.Individuals
                    .Where(i => i.Id == id)
                    .Include(i => i.Addresses)
                    .FirstOrDefaultAsync();

                if (individual == null)
                {
                    throw new NotFoundException(HttpStatusCode.NotFound,
                        $"The individual not found for the given id : {id}");
                }

                try
                {
                    dbContext.Individuals
                    .Remove(individual);

                    var result = await dbContext
                        .SaveChangesAsync();

                    return result;
                }
                catch (ApiException)
                {
                    //TODO logger
                    throw;
                }
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

        public async Task<IndividualDataDTO> GetIndividualByIdAsync(int id)
        {
            // get individual by id
            try
            {
                var individual = await dbContext.Individuals
                    .Where(i => i.Id == id)
                    .Include(i => i.Addresses)
                    .ProjectToType<IndividualDataDTO>()
                    .FirstOrDefaultAsync();

                if (individual == null)
                {
                    throw new NotFoundException(HttpStatusCode.NotFound,
                        $"The individual not found for the given id : {id}");
                }

                return individual;
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

        public async Task<int> CreateIndividualAsync(IndividualDataDTO individualDto)
        {
            // create new individual
            try
            {
                var individual = individualDto.Adapt<Individual>();

                var individualExist = dbContext.Individuals
                    .Where(i =>
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

        public async Task<int> UpdateIndividualAsync(IndividualDataDTO individual)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IndividualDataDTO>> GetAllIndividualsAsync()
        {
            // get all individuals
            try
            {
                var individuals = await dbContext
                    .Individuals
                    .Include(i => i.Addresses)
                    .ProjectToType<IndividualDataDTO>()
                    .ToListAsync();

                return individuals;
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
