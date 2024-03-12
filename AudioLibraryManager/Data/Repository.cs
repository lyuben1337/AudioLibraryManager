using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioLibraryManager.Data
{
    public class Repository<T>
    {
        private static Repository<T> instance;
        private List<T> items;

        public Repository(List<T> initialData)
        {
            items = initialData;
        }

        public Repository(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentException("JSON string is null or empty", nameof(json));
            }

            List<T> deserializedList = JsonConvert.DeserializeObject<List<T>>(json);

            if (deserializedList != null)
            {
                items = deserializedList;
            }
        }

        public static Repository<T> Instance
        {
            get
            {
                if (instance == null)
                {
                    throw new InvalidOperationException($"You must call Initialize with initial data before accessing {nameof(Instance)}");
                }
                return instance;
            }
        }
        public static void Initialize(List<T> initialData)
        {
            if (instance != null)
            {
                throw new InvalidOperationException($"{nameof(Instance)} is already initialized");
            }
            instance = new Repository<T>(initialData);
        }

        public static void Initialize(string json)
        {
            if (instance != null)
            {
                throw new InvalidOperationException($"{nameof(Instance)} is already initialized");
            }
            instance = new Repository<T>(json);
        }

        public List<T> GetAll()
        {
            return items;
        }

        public string ToJson()
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            try
            {
                string json = JsonConvert.SerializeObject(items, Formatting.Indented);
                return json;
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Failed to serialize to JSON: {ex.Message}", ex);
            }
        }

        public void Update(T oldItem, T newItem)
        {
            if(oldItem == null || newItem == null)
            {
                return;
            }
            
            var index = items.IndexOf(oldItem);
            if (index == -1)
            {
                return;
            }

            items[index] = newItem;
        }

        public void Delete(T item)
        {
            if (item == null)
            {
                return;
            }

            var index = items.IndexOf(item);

            if (index == -1)
            {
                return;
            }

            items.RemoveAt(index);
        }

        public void UpdateAll(List<T> updatedList)
        {
            items = updatedList;
        }

        public void Add(T item)
        {
            items.Add(item);
        }
    }
}
