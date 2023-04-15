namespace InSharpAssessment.DataRepositories.Models.Entities
{
    public class Individual : BaseEntity
    {
        public int Id { get; set; }
        public string?  FirstName { get; set; }
        public string? LastName { get; set; }
        public virtual List<Address>? Addresses { get; set; }
        public string? PhoneNumber { get; set; }
        public int AgeInYears { get; set; }

    }
}
