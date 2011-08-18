using System;
using System.Linq;
using NUnit.Framework;
using StructureMap;

namespace GeoffBurnsTaskList.Models.Test
{
  
 [TestFixture]
    class When_TaskList_Contains_Task_Due_Yesterday : When_TaskList_Contains_Task
    {

        [SetUp]
        public void SetUp()
        {
       
            SetUp(Yesterday);
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
        public void Then_TodaysTask_Should_Contain_Task_Overdue()
        {
            //Arrange

            //Act

            //Assert
            Assert.That(_taskListModel.TodaysTask.Any());
            Assert.That(_taskListModel.TodaysTask.Any(dt => dt.DueStatus.Equals("Overdue")));

        }

    }
}

