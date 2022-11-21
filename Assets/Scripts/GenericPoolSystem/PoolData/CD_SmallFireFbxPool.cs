using UnityEngine;

namespace GenericPoolSystem.PoolData
{
    [CreateAssetMenu(menuName = "PoolData/CD_SmallFireFbxPool", fileName = "CD_SmallFireFbxPool")]
    public class CD_SmallFireFbxPool : CD_AbstractPool<string>
    {
        private CD_SmallFireFbxPool()
        {
            Key = "SmallFire";
            InitialSize = 15;
            IsExtensible = false;
        }
    }
}