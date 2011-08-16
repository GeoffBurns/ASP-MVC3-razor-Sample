using GeoffBurnsTaskList.Models;
using GeoffBurnsTaskList.Properties;
using StructureMap;
namespace GeoffBurnsTaskList {
    public static class IoC {
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
                                    new JsonFilePersistentStore<Commitment>(System.Web.HttpContext.Current.Server.MapPath(Settings.Default.FileNameForPersistentStore)));
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