namespace InSharpAssessment.DataRepositories.Models.DTOs
{
    public class AddressDataDTO
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int? IndividualId { get; set; }
    }
}
