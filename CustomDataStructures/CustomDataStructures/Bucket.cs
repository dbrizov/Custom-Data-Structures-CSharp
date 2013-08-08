using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomDataStructures
{
    internal class Bucket<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private readonly LinkedList<KeyValuePair<TKey, TValue>> bucket;

        public Bucket()
        {
            this.bucket = new LinkedList<KeyValuePair<TKey, TValue>>();
        }

        public int Count
        {
            get
            {
                return this.bucket.Count;
            }
        }

        public TKey[] Keys
        {
            get
            {
                TKey[] keys = new TKey[this.Count];
                int index = 0;
                foreach (var pair in this.bucket)
                {
                    keys[index] = pair.Key;
                    index++;
                }

                return keys;
            }
        }

        public void Add(TKey key, TValue value)
        {
            KeyValuePair<TKey, TValue> pair = new KeyValuePair<TKey, TValue>(key, value);
            this.bucket.AddLast(pair);
        }

        public void Update(TKey key, TValue value)
        {
            foreach (var pair in this.bucket)
            {
                if (pair.Key.Equals(key))
                {
                    pair.Value = value;
                    break;
                }
            }
        }

        public bool Remove(TKey key)
        {
            bool removed = false;

            foreach (var pair in this.bucket)
            {
                if (pair.Key.Equals(key))
                {
                    this.bucket.Remove(pair);
                    removed = true;
                    break;
                }
            }

            return removed;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);
            bool found = false;
            foreach (var pair in this.bucket)
            {
                if (pair.Key.Equals(key))
                {
                    value = pair.Value;
                    found = true;
                    break;
                }
            }

            return found;
        }

        public bool ContainsKey(TKey key)
        {
            bool containsKey = false;
            foreach (var pair in this.bucket)
            {
                if (pair.Key.Equals(key))
                {
                    containsKey = true;
                    break;
                }
            }

            return containsKey;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var pair in this.bucket)
            {
                yield return pair;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
