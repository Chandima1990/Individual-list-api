namespace InSharpAssessment.Services.Models.ServiceDTOs
{
    public class IndividualServiceDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<AddressServiceDTO> Addresses { get; set; }
        public string? PhoneNumber { get; set; }
        public int AgeInYears { get; set; }
    }
    public class IndividualCreateServiceDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<AddressCreateServiceDTO> Addresses { get; set; }
        public string? PhoneNumber { get; set; }
        public int AgeInYears { get; set; }
    }

    public class IndividualUpdateServiceDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<AddressUpdateServiceDTO> Addresses { get; set; }
        public string? PhoneNumber { get; set; }
        public int AgeInYears { get; set; }
    }
}
