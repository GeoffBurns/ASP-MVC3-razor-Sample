using System;
using System.Linq;
using NUnit.Framework;
using StructureMap;

namespace GeoffBurnsTaskList.Models.Test
{
  
 [TestFixture]
    class When_TaskList_Contains_Task_Due_Yesterday
    {
        private IContainer _container;

        [SetUp]
        public void SetUp()
        {
           _container = (IContainer)IoC.Initialize();
            var mock = IoC.MockStore;
            mock.Setup(s => s.GetItems()).Returns(new[] { new Commitment { DueDate = DateTime.Now.AddDays(-1) } });
        }
        [Test]
        public void Then_AreTaskDue_Should_be_True()
        {
            //Arrange
            var taskList = _container.GetInstance<ITaskListModel>();

            //Act
            
            //Assert
            Assert.That(taskList.AreTasksDue);
        }
        [Test]
        public void Then_TodaysTask_Should_Contain_Task_Overdue()
        {
            //Arrange
            var taskList = _container.GetInstance<ITaskListModel>();

            //Act

            //Assert
            Assert.That(taskList.TodaysTask.Any());
            Assert.That(taskList.TodaysTask.Any(dt => dt.DueStatus.Equals("Overdue")));

        }

    }
}

