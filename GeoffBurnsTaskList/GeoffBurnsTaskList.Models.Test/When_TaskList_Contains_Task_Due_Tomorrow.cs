using System;
using System.Linq;
using NUnit.Framework;
using StructureMap;

namespace GeoffBurnsTaskList.Models.Test
{
  
 [TestFixture]
    class When_TaskList_Contains_Task_Due_Tomorrow :  When_TaskList_Contains_Task
    {
        [SetUp]
        public void SetUp()
        {
            SetUp(Tomorrow);
        }
        [Test]
        public void Then_AreTaskDue_Should_be_False()
        {
            //Arrange

            //Act
            
            //Assert
            Assert.False(_taskListModel.AreTasksDue);
        }
        [Test]
        public void Then_TodaysTask_Should_not_Contain_Task_DueToday()
             {
            //Arrange

            //Act

            //Assert
                 Assert.False(_taskListModel.TodaysTask.Any());  
        }

    }
}

