using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenericPoolSystem.PoolData
{
    [CreateAssetMenu(fileName = "CD_Pools", menuName = "BaseDefence/Pool/CD_Pools", order = 0)]
    public class CD_Pools : ScriptableObject
    {
        public List<CD_AbstractPool<string>> Pools;
    }
}