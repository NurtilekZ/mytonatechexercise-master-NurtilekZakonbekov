using UnityEngine;

namespace Myproject.Collectables
{
    public abstract class Collectable : MonoBehaviour
    {
        protected abstract void OnTriggerEnter(Collider other);
    }
}