namespace InSharpAssessment.DataRepositories.Models.Entities
{
    public abstract class BaseEntity
    {
        public DateTime AddedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
