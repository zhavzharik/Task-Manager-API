using System;

namespace MyTasks.Domain
{
    public class MyTask
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public MyTaskType Type { get; set; }
        public string Description { get; set; }
        public DateTime CompletedDate { get; set; }
        public CompletedStatus IsCompleted { get; set; }
    }

    public enum MyTaskType
    {
        Work,
        Personal,
    }

    public enum CompletedStatus
    {
        NotComleted,
        Done,
    }
}
