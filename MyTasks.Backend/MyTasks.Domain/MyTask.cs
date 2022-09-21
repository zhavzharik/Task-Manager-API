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
        public CompletedBool IsCompleted { get; set; }
    }

    public enum MyTaskType
    {
        Work = 1,
        Personal = 2,
    }

    public enum CompletedBool
    {
        False = 0,
        True = 1,
    }
}
