using TodoEc2.Domain.Enums;

namespace TodoEc2.Domain.Entities
{
    public class Schedules : EntityBase
    {
        public Enums.Schedules Date { get; set; }

        public long TodoId { get; set; }
    }
}
