using GeoffBurnsTaskList.Models;
using Moq;
using StructureMap;
namespace GeoffBurnsTaskList {
    public static class IoC
    {
        public static Mock<IPersistentStore<Commitment>> MockStore = new Mock<IPersistentStore<Commitment>>();
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<IPersistentStore<Commitment>>()
                                .Singleton()
                                .Use(
                                    () =>
                                    MockStore.Object);
                            x.For<ITaskListModel>()
                                .Singleton()
                                .Use<TaskListModel>();
                            x.For<IRepository<Commitment>>()
                             .Singleton()
                             .Use<Repository<Commitment>>();
                        });
            return ObjectFactory.Container;
        }
    }
}