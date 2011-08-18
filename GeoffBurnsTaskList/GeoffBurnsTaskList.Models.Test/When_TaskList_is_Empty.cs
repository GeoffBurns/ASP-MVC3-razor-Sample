using System.Linq;
using NUnit.Framework;
using StructureMap;

namespace GeoffBurnsTaskList.Models.Test
{
    [TestFixture]
    class When_TaskList_is_Empty
    {
        private IContainer _container;
        private ITaskListModel _taskListModel;
        private IRepository<Commitment> _repo;

        [SetUp]
        public void SetUp()
        {
           _container = IoC.Initialize();
           var mock = IoC.MockStore;
           mock.Setup(s => s.GetItems()).Returns(Enumerable.Empty<Commitment>());

           _repo = _container.GetInstance<IRepository<Commitment>>();
           _taskListModel = _container.GetInstance<ITaskListModel>();

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
        public void Then_TodaysTask_Should_be_Empty()
        {
            //Arrange

            //Act

            //Assert
            Assert.False(_taskListModel.TodaysTask.Any());
        }
        [Test]
        public void And_New_Task_is_Added_Then_TodaysTask_Should_not_be_Empty()
        {
            //Arrange

            //Act
            _repo.Create(new Commitment());

            //Assert
            Assert.That(_taskListModel.TodaysTask.Any());
            Assert.That(_taskListModel.AreTasksDue);
        }

    [TearDown]
    public void TearDown()
    {
        _repo.DeleteAll();
    }
    }
}
