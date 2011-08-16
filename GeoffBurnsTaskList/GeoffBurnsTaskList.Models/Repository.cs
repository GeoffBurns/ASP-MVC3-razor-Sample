using System;
using System.Collections.Generic;
using System.Linq;

namespace GeoffBurnsTaskList.Models
{
    public class Repository<T> : IRepository<T> where T : new()
    {
        public IPersistentStore<T> Store { get; set; }

        public Repository(IPersistentStore<T> store)
        {
            Store = store;
            try
            {   
                Items = Store.GetItems().ToList();
            }
            catch (Exception ex)
            {
                StoreList();
            }
        }

        private void StoreList()
        {
            Store.SaveItems(Items);
        }

        private List<T> _items;
        public List<T> Items
        {
            get { return _items ?? (_items = new List<T>()); }
            private set { _items = value; }
        }

        public void Create(T newItem)
        {
            Items.Add(newItem);
         
            StoreList();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }


        public T GetDefault()
        {
            return new T();
        }

        public void DeleteAll()
        {
            Items = Enumerable.Empty<T>().ToList();
            StoreList();
        }
    }
}