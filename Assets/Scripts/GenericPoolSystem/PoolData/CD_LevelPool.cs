using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GenericPoolSystem.PoolData
{
    [CreateAssetMenu(menuName = "PoolData/CD_LevelPool", fileName = "CD_LevelPool")]
    public class CD_LevelPool : CD_AbstractPool<string>
    {
        CD_LevelPool()
        {
            Key = "Level";
            InitialSize = 5;
            IsExtensible = false;
        }
    }
}
