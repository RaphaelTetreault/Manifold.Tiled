using System.Collections;

namespace Manifold.Tiled
{
    public class TiledCollection<T> : 
        IEnumerable<T>
        where T : INamed
    {
        public Dictionary<string, T> Dictionary { get; set; } = new Dictionary<string, T>();
        public T[] Array => Dictionary.Values.ToArray();
        public IEnumerator<T> Iterator => Dictionary.Values.GetEnumerator();


        public T this[string key] { get => Dictionary[key]; set => Dictionary[key] = value; }


        public IEnumerator<T> GetEnumerator()
        {
            return Iterator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public void AddRange(T[] values)
        {
            foreach (var value in values)
                Dictionary.Add(value.Name, value);
        }
    }
}
