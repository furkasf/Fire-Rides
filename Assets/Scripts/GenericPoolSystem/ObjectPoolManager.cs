using System;
using System.Collections.Generic;

namespace GenericPoolSystem
{
    public class ObjectPoolManager
    {
        private readonly Dictionary<string, AbstractObjectPool> _pools;
        private static ObjectPoolManager _instance;

        public static ObjectPoolManager Instance
        {
            get
            {
                if (_instance == null) _instance = new ObjectPoolManager();
                return _instance;
            }
        }

        public ObjectPoolManager()
        {
            _pools = new Dictionary<string, AbstractObjectPool>();
        }

        #region Pool Initializations

        public void AddObjectPool<T>(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, Action<T> putHolder, string poolName, int initialStock = 0, bool isDynamic = true)
        {
            if (!_pools.ContainsKey(poolName))
                _pools.Add(poolName, new ObjectPool<T>(factoryMethod, turnOnCallback, turnOffCallback, putHolder, initialStock, isDynamic));
        }

        public void AddObjectPool<T>(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, Queue<T> initialStock, string poolName, bool isDynamic = true) where T : AbstractObjectPool, new()
        {
            if (!_pools.ContainsKey(poolName))
                _pools.Add(poolName, new ObjectPool<T>(factoryMethod, turnOnCallback, turnOffCallback, initialStock, isDynamic));
        }

        public void AddObjectPool(AbstractObjectPool pool, string poolName)
        {
            if (_pools.ContainsKey(poolName))
                _pools.Add(poolName, pool);
        }

        #endregion Pool Initializations

        #region Pool Controlls

        public ObjectPool<T> GetObjectPool<T>(string poolName)
        {
            return (ObjectPool<T>)_pools[poolName];
        }

        public T GetObject<T>(string poolName)
        {
            return ((ObjectPool<T>)_pools[poolName]).GetObject();
        }

        public void ReturnObject<T>(T o, string poolName)
        {
            ((ObjectPool<T>)_pools[poolName]).ReturnObject(o);
        }

        public void RemovePool(string poolName)
        {
            _pools[poolName] = null;
        }

        #endregion Pool Controlls

        #region Pool DataAcceses

        public int PoolCurrentSize(string poolName)
        {
            return _pools[poolName].GetPoolCurrentSize();
        }

        public bool PoolIsDynamic(string poolName)
        {
            return _pools[poolName].GetPoolIsDynamic();
        }

        #endregion Pool DataAcceses
    }
}
/// possible improvement convert keys to genrics
