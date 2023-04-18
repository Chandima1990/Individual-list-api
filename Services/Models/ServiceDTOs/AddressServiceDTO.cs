namespace InSharpAssessment.Services.Models.ServiceDTOs
{
    public class AddressServiceDTO
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int? IndividualId { get; set; }
    }

    public class AddressCreateServiceDTO
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int? IndividualId { get; set; }
    }

    public class AddressUpdateServiceDTO
    {
        public int? Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int? IndividualId { get; set; }
    }

}
