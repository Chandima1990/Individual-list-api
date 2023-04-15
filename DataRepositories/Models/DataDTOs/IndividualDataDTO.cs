using InSharpAssessment.DataRepositories.Models.Entities;

namespace InSharpAssessment.DataRepositories.Models.DTOs
{
    public class IndividualDataDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<Address>? Addresses { get; set; }
        public string? PhoneNumber { get; set; }
        public int AgeInYears { get; set; }
    }
}
