using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JellyfinCLI
{
    public class Trigger
    {
        public string? Type { get; set; }
        public long? IntervalTicks { get; set; }
        public long? TimeOfDayTicks { get; set; }
        public long? MaxRunTimeTicks { get; set; }
    }
    public class LastExecutionResult
    {
        public DateTime? StartTimeUtc { get; set; }
        public DateTime? EndTimeUtc { get; set; }
        public string? Status { get; set; }
        public string? Name { get; set; }
        public string? Key { get; set; }
        public string? Id { get; set; }
    }
    public class TaskInfo
    {
        public string? Name { get; set; }
        public string? State { get; set; }
        public string? Id { get; set; }
        public LastExecutionResult? LastExecutionResult { get; set; }
        public List<Trigger>? Triggers { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public bool? IsHidden { get; set; }
        public string? Key { get; set; }
    }
}
