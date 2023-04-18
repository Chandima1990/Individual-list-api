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

                    if (result != true)
                    {
                        throw new ConflictException(HttpStatusCode.Conflict,
                            $"Deleting the record for the id : {id} failed!");
                    }

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

                await dbContext.Individuals
                    .AddAsync(individual);

                var result = await dbContext.SaveChangesAsync();

                if (result != true)
                {
                    throw new ConflictException(HttpStatusCode.Conflict,
                           $"Creating individual failed!");
                }

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

        public async Task<int> UpdateIndividualAsync(IndividualDataDTO individualDto)
        {
            // update individual
            try
            {
                var individual = await dbContext.Individuals
                    .Include(i => i.Addresses)
                    .FirstOrDefaultAsync(i => i.Id == individualDto.Id);

                // individual not found
                if (individual == null)
                {
                    throw new ConflictException(HttpStatusCode.NotFound,
                        "The individual not found in the system");
                }

                individual.FirstName = individualDto.FirstName;
                individual.LastName = individualDto.LastName;
                individual.PhoneNumber = individualDto.PhoneNumber;
                individual.AgeInYears = individualDto.AgeInYears;

                //Update the existing addresses
                var updatedAdresses = individualDto.Addresses
                    .Where(a => a.Id != 0)
                    .Adapt<List<Address>>();

                //loop through the updated addresses
                foreach (var address in updatedAdresses)
                {
                    var dbAddress = individual.Addresses
                        .FirstOrDefault(a => a.Id == address.Id);

                    if (dbAddress != null)
                    {
                        dbAddress.Street = address.Street;
                        dbAddress.City = address.City;
                        dbAddress.Country = address.Country;
                    }
                }

                //Add new addresses
                var addedAddresses = individualDto.Addresses
                    .Where(a => a.Id == 0)
                    .Adapt<List<Address>>();

                individual.Addresses
                    .AddRange(addedAddresses);

                var result = await dbContext
                    .SaveChangesAsync();

                if (result != true)
                {
                    throw new ConflictException(HttpStatusCode.Conflict,
                           $"Updating individual failed!");
                }

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

        public async Task<PagedDataDTO<IndividualDataDTO>> GetAllIndividualsAsync(int page, int pageSize)
        {
            // get all individuals
            try
            {
                var individuals = dbContext
                    .Individuals
                    .Include(i => i.Addresses);

                var pagedIndividuals = await TakePage(individuals, page, pageSize);

                return pagedIndividuals;
            }
            catch (Exception ex)
            {
                // unhandled server error
                // TODO logger
                throw new ServerErrorException(ex);
            }
        }

        private async Task<PagedDataDTO<IndividualDataDTO>> TakePage(IQueryable<Individual> data, int page, int pageSize)
        {
            var startIndex = (page - 1) * pageSize;
            var endIndex = page * pageSize;
            var results = await data
                .Skip(startIndex)
                .Take(pageSize)
                .ProjectToType<IndividualDataDTO>()
                .ToListAsync();

            int? previousPage = null;
            int? nextPage = null;

            if (startIndex > 0)
            {
                //previousPage exist
                previousPage = page - 1;
            }
            if (endIndex < data.Count())
            {
                //nextPage exist
                nextPage = page + 1;
            }

            return new PagedDataDTO<IndividualDataDTO>()
            {
                Total = data.Count(),
                Page = page,
                PageSize = pageSize,
                Data = results,
                NextPage = nextPage,
                PreviousPage = previousPage
            };
        }
    }
}
