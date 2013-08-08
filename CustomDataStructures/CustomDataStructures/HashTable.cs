using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomDataStructures
{
    public class HashTable<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private const int InitialCapacity = 16;
        private const double LoadFactor = 0.75;

        private Bucket<TKey, TValue>[] buckets;
        private int count;
        private int capacity;

        public HashTable()
        {
            this.buckets = new Bucket<TKey, TValue>[InitialCapacity];
            this.count = 0;
            this.capacity = InitialCapacity;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public TKey[] Keys
        {
            get
            {
                int elementCount = 0;
                TKey[] keys = new TKey[this.count];
                for (int i = 0; i < this.buckets.Length; i++)
                {
                    if (this.buckets[i] != null)
                    {
                        var currentKeys = this.buckets[i].Keys;
                        for (int j = 0; j < currentKeys.Length; j++)
                        {
                            keys[elementCount] = currentKeys[j];
                            elementCount++;
                        }
                    }
                }

                return keys;
            }
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key", "The key can't have a null value");
            }

            if (this.NeedsToBeResized())
            {
                this.Resize();
            }

            int index = this.GetIndex(key);
            if (this.buckets[index] == null)
            {
                this.buckets[index] = new Bucket<TKey, TValue>();
                this.buckets[index].Add(key, value);
                this.count++;
            }
            else
            {
                bool keyAlreadyExists = this.buckets[index].ContainsKey(key);
                if (keyAlreadyExists)
                {
                    this.buckets[index].Update(key, value);
                }
                else
                {
                    this.buckets[index].Add(key, value);
                    this.count++;
                }
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);
            int index = this.GetIndex(key);
            bool found = false;
            if (this.buckets[index] != null)
            {
                found = this.buckets[index].TryGetValue(key, out value);
            }

            return found;
        }

        public TValue Find(TKey key)
        {
            TValue value;
            if (this.TryGetValue(key, out value))
            {
                return value;
            }

            throw new KeyNotFoundException("There is not pair with such a key");
        }

        public bool Remove(TKey key)
        {
            bool removed = false;

            int index = this.GetIndex(key);
            if (this.buckets[index] != null)
            {
                removed = this.buckets[index].Remove(key);
            }

            if (removed)
            {
                this.count--;
            }

            return removed;
        }

        public bool ContainsKey(TKey key)
        {
            int index = this.GetIndex(key);
            bool containsKey = false;
            if (this.buckets[index] != null)
            {
                containsKey = this.buckets[index].ContainsKey(key);
            }

            return containsKey;
        }

        public void Clear()
        {
            this.buckets = new Bucket<TKey, TValue>[InitialCapacity];
            this.count = 0;
            this.capacity = 16;
        }

        public TValue this[TKey key]
        {
            get
            {
                return this.Find(key);
            }

            set
            {
                this.SetValue(key, value);
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var bucket in this.buckets)
            {
                if (bucket != null)
                {
                    foreach (var pair in bucket)
                    {
                        yield return pair;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int GetIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode() % this.capacity);
        }

        private void Resize()
        {
            this.capacity *= 2;
            Bucket<TKey, TValue>[] oldBuckets = this.buckets;
            this.buckets = new Bucket<TKey, TValue>[this.capacity];
            this.count = 0;

            foreach (var bucket in oldBuckets)
            {
                if (bucket != null)
                {
                    foreach (var pair in bucket)
                    {
                        this.Add(pair.Key, pair.Value);
                    }
                }
            }
        }

        private bool NeedsToBeResized()
        {
            double currentLoad = (double)this.count / this.capacity;
            return currentLoad >= LoadFactor;
        }

        private void SetValue(TKey key, TValue value)
        {
            bool keyAlreadyExists = this.ContainsKey(key);
            if (keyAlreadyExists)
            {
                int index = this.GetIndex(key);
                this.buckets[index].Update(key, value);
            }
            else
            {
                throw new KeyNotFoundException("There is no pair with such a key");
            }
        }
    }
}
