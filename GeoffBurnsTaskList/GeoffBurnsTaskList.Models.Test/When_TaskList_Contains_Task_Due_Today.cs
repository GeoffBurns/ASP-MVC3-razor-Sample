using System;
using System.Linq;
using NUnit.Framework;


namespace GeoffBurnsTaskList.Models.Test
{
    [TestFixture]
    public class When_TaskList_Contains_Task_Due_Today : When_TaskList_Contains_Task
    {
        [SetUp]
        public void SetUp()
        {
            SetUp(Today);
        }
        [Test]
        public void Then_AreTaskDue_Should_be_True()
        {
            //Arrange

            //Act
            
            //Assert
            Assert.That(_taskListModel.AreTasksDue);
        }
        [Test]
        public void Then_TodaysTask_Should_Contain_Task_DueToday()
        {
            //Arrange

            //Act

            //Assert
            Assert.That(_taskListModel.TodaysTask.Any());
            Assert.That(_taskListModel.TodaysTask.Any(dt => dt.DueStatus.Equals("Due Today")));
            
        }
    }
}
