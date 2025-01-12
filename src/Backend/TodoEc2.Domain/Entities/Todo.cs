using TodoEc2.Domain.Enums;

namespace TodoEc2.Domain.Entities
{
    public class Todo : EntityBase
    {
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public Status Status { get; set; }

        public long UserId { get; set; }

        public IList<Schedules> Dates { get; set; } = [];
    }
}
