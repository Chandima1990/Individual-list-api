namespace InSharpAssessment.DataRepositories.Models.Entities
{
    public class Address : BaseEntity
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int? IndividualId { get; set; }
        public virtual Individual? Individual { get; set; }
    }
}
