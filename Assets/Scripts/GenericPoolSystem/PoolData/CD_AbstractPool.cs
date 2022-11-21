using System;
using UnityEngine;

namespace GenericPoolSystem.PoolData
{
    public abstract class CD_AbstractPool<T> : ScriptableObject where T : class
    {
        public GameObject Prefab;
        public T Key;
        public int InitialSize;
        public bool IsExtensible;

        public virtual void ActivatePrefab(GameObject gameObject) => gameObject.SetActive(true);
        public virtual void DeactivatePrefab(GameObject gameObject) => gameObject.SetActive(false);
        public virtual GameObject PrefabFactory() => GameObject.Instantiate(Prefab);
    }
}