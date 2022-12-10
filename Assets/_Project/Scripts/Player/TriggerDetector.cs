using _Project.Scripts.Interfaces;
using Collectable;
using UnityEngine;

namespace Player
{
    public class TriggerDetector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ITriggerable triggable)) triggable.Trigger(this);
        }
    }
}

