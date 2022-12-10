using Player;
using UnityEngine;

namespace Collectable
{
    public class Gold : MonoBehaviour, ICollectable
    {
        [SerializeField] private Resource currencyResource;
        public void Collect(Collector collector)
        {
            currencyResource.Increase();
        }
    }
}