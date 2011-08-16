using System;
using System.Linq;
using NUnit.Framework;
using StructureMap;

namespace GeoffBurnsTaskList.Models.Test
{
  
 [TestFixture]
    class When_TaskList_Contains_Task_Due_Tomorrow
    {
        private IContainer _container;

        [SetUp]
        public void SetUp()
        {
           _container = (IContainer)IoC.Initialize();
            var mock = IoC.MockStore;
            mock.Setup(s => s.GetItems()).Returns(new[] {new Commitment{DueDate = DateTime.Now.AddDays(1)}});
        }
        [Test]
        public void Then_AreTaskDue_Should_be_False()
        {
            //Arrange
            var taskList = _container.GetInstance<ITaskListModel>();

            //Act
            
            //Assert
            Assert.False(taskList.AreTasksDue);
        }
        [Test]
        public void Then_TodaysTask_Should_not_Contain_Task_DueToday()
             {
            //Arrange
            var taskList = _container.GetInstance<ITaskListModel>();

            //Act

            //Assert
            Assert.False(taskList.TodaysTask.Any());
            
        }
    }
}

