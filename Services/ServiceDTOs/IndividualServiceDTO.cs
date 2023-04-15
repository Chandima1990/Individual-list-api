namespace InSharpAssessment.DataRepositories.Models.DTOs
{
    internal class IndividualServiceDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<AddressServiceDTO> Addresses { get; set; }
        public string? PhoneNumber { get; set; }
        public int AgeInYears { get; set; }
    }
}
