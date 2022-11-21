using UnityEngine;

namespace Level
{
    public class LevelLoaderCommand
    {
        public void LevelLoad(int _levelID, ref Transform levelHolder)
        {
            GameObject level = GameObject.Instantiate(Resources.Load<GameObject>($"LevelPrefabs/Level{_levelID}"), levelHolder);
        }
    }
}