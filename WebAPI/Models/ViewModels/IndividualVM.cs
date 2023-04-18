namespace InSharpAssessment.WebAPI.Models.ViewModels
{
    public class IndividualCreateVM
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<AddressCreateVM> Addresses { get; set; }
        public string? PhoneNumber { get; set; }
        public int AgeInYears { get; set; }
    }

    public class IndividualUpdateVM
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<AddressUpdateVM> Addresses { get; set; }
        public string? PhoneNumber { get; set; }
        public int AgeInYears { get; set; }
    }

    public class IndividualVM
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<AddressVM> Addresses { get; set; }
        public string? PhoneNumber { get; set; }
        public int AgeInYears { get; set; }
    }
}
