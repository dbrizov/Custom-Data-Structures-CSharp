using System;

namespace CustomDataStructures
{
    public class KeyValuePair<TKey, TValue>
    {
        public TKey Key { get; private set; }
        public TValue Value { get; set; }

        public KeyValuePair(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", this.Key, this.Value);
        }
    }
}
