namespace InSharpAssessment.WebAPI.Models.ViewModels
{
    public class AddressCreateVM
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }

    public class AddressUpdateVM
    {
        public int? Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int? IndividualId { get; set; }
    }

    public class AddressVM
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int? IndividualId { get; set; }
    }
}
