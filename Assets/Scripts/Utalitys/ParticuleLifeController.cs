using GenericPoolSystem;
using UnityEngine;

namespace Assets.Scripts
{
    public class ParticuleLifeController : MonoBehaviour
    {
        private void OnEnable()
        {
            Invoke("PoolBachToPaticule", 2.4f);
        }

        private void PoolBachToPaticule()
        {
            PoolSignals.onPutObjectBackToPool(gameObject, "SmallFire");
        }
    }
}