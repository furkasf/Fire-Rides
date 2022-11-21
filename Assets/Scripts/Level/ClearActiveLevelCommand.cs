using System.Threading.Tasks;
using UnityEngine;

namespace Level
{
    public class ClearActiveLevelCommand
    {
        public void ClearActiveLevelAsync(ref Transform levelHolder)
        {
            GameObject.Destroy(levelHolder.GetChild(0).gameObject);
        }
    }
}