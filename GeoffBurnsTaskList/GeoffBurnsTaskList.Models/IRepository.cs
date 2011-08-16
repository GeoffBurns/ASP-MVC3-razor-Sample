using System.Collections.Generic;

namespace GeoffBurnsTaskList.Models
{
    public interface IRepository<T> : IEnumerable<T> where T : new()
    {
        void Create(T newItem);
        T GetDefault();
        void DeleteAll();
    }
}