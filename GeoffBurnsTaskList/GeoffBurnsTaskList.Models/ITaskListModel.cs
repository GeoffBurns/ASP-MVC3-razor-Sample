using System.Collections.Generic;

namespace GeoffBurnsTaskList.Models
{
    public interface ITaskListModel
    {
        bool AreTasksDue { get; }
        IEnumerable<DueTask> TodaysTask { get; }
        IEnumerable<Commitment> AllTasks { get; }
        IEnumerable<Commitment> TaskForLater { get; }
    }
}