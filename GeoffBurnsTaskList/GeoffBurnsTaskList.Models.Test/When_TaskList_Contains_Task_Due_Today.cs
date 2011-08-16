using System.Linq;
using NUnit.Framework;
using StructureMap;


namespace GeoffBurnsTaskList.Models.Test
{
    [TestFixture]
    class When_TaskList_Contains_Task_Due_Today
    {
        private IContainer _container;

        [SetUp]
        public void SetUp()
        {
           _container = (IContainer)IoC.Initialize();
            var mock = IoC.MockStore;
            mock.Setup(s => s.GetItems()).Returns(new[] {new Commitment()});
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
        public void Then_TodaysTask_Should_Contain_Task_DueToday()
        {
            //Arrange
            var taskList = _container.GetInstance<ITaskListModel>();

            //Act

            //Assert
            Assert.That(taskList.TodaysTask.Any());
            Assert.That(taskList.TodaysTask.Any(dt=>dt.DueStatus.Equals("Due Today")));
            
        }
    }
}
