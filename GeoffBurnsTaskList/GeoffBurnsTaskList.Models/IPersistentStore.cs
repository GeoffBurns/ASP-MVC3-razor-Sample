using System.Collections.Generic;

namespace GeoffBurnsTaskList.Models
{
    public interface IPersistentStore<T>
    {
        IEnumerable<T> GetItems();
        void SaveItems(IEnumerable<T> items);
    }
}