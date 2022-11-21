using System;
using UnityEngine;

namespace GenericPoolSystem
{
    public static class PoolSignals
    {
        public static Func<string, GameObject> onGetObjectFormPool;
        public static Func<string, int> onGetPoolCurrentSize;
        public static Func<string, bool> onGetPoolIsDynamic;
        public static Action<GameObject, string> onPutObjectBackToPool;
    }
}