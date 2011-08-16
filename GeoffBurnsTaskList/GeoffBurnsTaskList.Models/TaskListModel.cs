using System;
using System.Collections.Generic;
using System.Linq;

namespace GeoffBurnsTaskList.Models
{
    public class TaskListModel : ITaskListModel
    {
        private readonly IEnumerable<Commitment> _commitments;

        public TaskListModel(IRepository<Commitment> commitments)
        {
            _commitments = commitments;
        }

        public bool AreTasksDue
        {
            get { return _commitments.Any(c => c.DueDate.Date <= DateTime.Now.Date); }
        }

        public IEnumerable<DueTask> TodaysTask
        {
            get
            {
                return _commitments
                    .Where(c => c.DueDate.Date <= DateTime.Now.Date)
                    .Select(
                        c =>
                        new DueTask
                            {
                                Task = c.Task,
                                Priority = c.Priority,
                                DueStatus = c.DueDate < DateTime.Now.Date ? "Overdue" : "Due Today"
                            });
            }
        }

        public IEnumerable<Commitment> TaskForLater
        {
            get { return _commitments.Where(c => c.DueDate >= DateTime.Now.Date); }
        }


        public IEnumerable<Commitment> AllTasks
        {
            get { return _commitments; }
        }
    }
}