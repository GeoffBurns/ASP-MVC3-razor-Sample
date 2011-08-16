using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GeoffBurnsTaskList.Models
{
    public class JsonFilePersistentStore<T> : IPersistentStore<T>
    {
        public JsonFilePersistentStore(string fileNameForPersistentStore )
        {
            _fileNameForPersistentStore = fileNameForPersistentStore;
        }
        private readonly JsonSerializer _serializer = new JsonSerializer();
        private readonly string _fileNameForPersistentStore;
        public IEnumerable<T> GetItems()
        {
            using (var fs = new FileStream(_fileNameForPersistentStore, FileMode.Open))
            using (var sr = new StreamReader(fs))
            using (var reader = new JsonTextReader(sr))
            {
                return _serializer.Deserialize<IEnumerable<T>>(reader).ToList();
            }
        }

        public void SaveItems(IEnumerable<T> items)
        {
            using (var fs = new FileStream(_fileNameForPersistentStore, FileMode.Create))  
            using (var sw = new StreamWriter(fs))
            using (var writer = new JsonTextWriter(sw))
            {
                _serializer.Serialize(writer, items);
            }
        }
    }
}


