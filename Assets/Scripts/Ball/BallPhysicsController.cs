using Assets.Scripts;
using Level;
using UnityEngine;

namespace Ball
{
    public class BallPhysicsController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("LevelTrigger"))
            {
                LevelSignals.onGetNextLevel();
                CameraSiganls.onChangeColor();
            }
            if (other.CompareTag("SmalPrize"))
            {
                other.transform.parent.gameObject.SetActive(false);
                UISignals.onActivateComboScore();
            }
            if (other.CompareTag("BigPrize"))
            {
                other.transform.parent.gameObject.SetActive(false);
                UISignals.onActivateComboScore();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Wall"))
            {
                //StartCoroutine(CameraSiganls.OnScreanShootToTexture());
                CameraSiganls.onTargetDeath();
                LevelSignals.onClearLevel();
                LevelSignals.onLoadLevel();
                CameraSiganls.onResetColor();
            }
        }
    }
}