using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardReset : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjects;

    private void OnEnable()
    {
        ResetObstical();
    }

    private void ResetObstical()
    {
        foreach(GameObject obj in gameObjects)
        {
            obj.SetActive(true);
        }
    }
}
