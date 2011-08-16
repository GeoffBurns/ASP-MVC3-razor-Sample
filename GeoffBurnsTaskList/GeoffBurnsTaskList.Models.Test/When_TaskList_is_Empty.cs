using System.Linq;
using NUnit.Framework;
using StructureMap;

namespace GeoffBurnsTaskList.Models.Test
{
    [TestFixture]
    class When_TaskList_is_Empty
    {
        private IContainer _container;

        [SetUp]
        public void SetUp()
        {
           _container = (IContainer)IoC.Initialize();
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
        public void Then_TodaysTask_Should_be_Empty()
        {
            //Arrange
            var taskList = _container.GetInstance<ITaskListModel>();

            //Act

            //Assert
            Assert.False(taskList.TodaysTask.Any());
        }
        [Test]
        public void And_New_Task_is_Added_Then_TodaysTask_Should_not_be_Empty()
        {
            //Arrange

            var repo = _container.GetInstance<IRepository<Commitment>>();
            var taskList = _container.GetInstance<ITaskListModel>();

            //Act
            repo.Create(new Commitment());

            //Assert
            Assert.That(taskList.TodaysTask.Any());
            Assert.That(taskList.AreTasksDue);
        }
    }
}
