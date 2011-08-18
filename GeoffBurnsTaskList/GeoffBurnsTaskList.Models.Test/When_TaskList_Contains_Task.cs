using System;
using NUnit.Framework;
using StructureMap;

namespace GeoffBurnsTaskList.Models.Test
{
    public class When_TaskList_Contains_Task
    {
        private IContainer _container;
        protected ITaskListModel _taskListModel;
        private IRepository<Commitment> _repo;
        protected static DateTime Today = DateTime.Now;
        protected static DateTime Tomorrow = DateTime.Now.AddDays(1);
        protected static DateTime Yesterday = DateTime.Now.AddDays(-1);

        public void SetUp(DateTime date)
        {
            _container = IoC.Initialize();
            var mock = IoC.MockStore;
            mock.Setup(s => s.GetItems()).Returns(new[] { new Commitment { DueDate = date } });

            _taskListModel = _container.GetInstance<ITaskListModel>();
            _repo = _container.GetInstance<IRepository<Commitment>>();
        }

        [TearDown]
        public void TearDown()
        {
            _repo.DeleteAll();
        }
    }
}