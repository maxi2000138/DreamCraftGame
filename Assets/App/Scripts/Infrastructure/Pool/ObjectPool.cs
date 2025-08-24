﻿using System;
using System.Collections.Generic;
using App.Scripts.Infrastructure.Logger;

namespace App.Scripts.Infrastructure.Pool
{
    public sealed class ObjectPool<T>
    {
        private readonly IList<ObjectPoolContainer<T>> _list;
        private readonly IDictionary<T, ObjectPoolContainer<T>> _lookup;
        private readonly Func<T> _factoryFunc;
	    
        private int _lastIndex = 0;

        public int Count => _list.Count;
        public int CountUsedItems => _lookup.Count;

        public ObjectPool(Func<T> factoryFunc, int size)
        {
            _factoryFunc = factoryFunc;

            _list = new List<ObjectPoolContainer<T>>(size);
            _lookup = new Dictionary<T, ObjectPoolContainer<T>>(size);

            Warm(size);
        }

        private void Warm(int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                CreateContainer();
            }
        }

        private ObjectPoolContainer<T> CreateContainer()
        {
            ObjectPoolContainer<T> container = new ObjectPoolContainer<T>
            {
                Item = _factoryFunc()
            };
		    
            _list.Add(container);
		    
            return container;
        }

        public T GetItem()
        {
            ObjectPoolContainer<T> container = null;
		    
            for (int i = 0; i < _list.Count; i++)
            {
                _lastIndex++;

                if (_lastIndex > _list.Count - 1)
                {
                    _lastIndex = 0;
                }

                if (!_list[_lastIndex].Used)
                {
                    container = _list[_lastIndex];
                    break;
                }
            }

            if (container == null)
            {
                container = CreateContainer();
            }

            container.Consume();

            _lookup.Add(container.Item, container);
		    
            return container.Item;
        }

        public ObjectPoolContainer<T> GetContainer(T item) => _lookup[item];

        public void ReleaseItem(T item)
        {
            if (_lookup.ContainsKey(item))
            {
                ObjectPoolContainer<T> container = _lookup[item];
                container.Release();
                _lookup.Remove(item);
            }
            else
            {
                DebugLogger.LogWarning($"This object pool does not contain the item provided: {item}", LogsType.Pool);
            }
        }

        public void ReleaseAll()
        {
            foreach (ObjectPoolContainer<T> container in _lookup.Values)
            {
                container.Release();
            }
            
            _lookup.Clear();
        }
    }
}