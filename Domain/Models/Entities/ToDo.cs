namespace Domain.Models.Entities
{
    public class ToDo
    {


        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsCompleted { get; set; }
        public required string PriorityLevel { get; set; }
        public DateOnly DateCreated { get; set; }
        public DateOnly DateDue { get; set; }

    }
}
