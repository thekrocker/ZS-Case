using Player;
using UnityEngine;

namespace Collectable
{
    public class Gold : CollectableItem
    {
        public override void Collect()
        {
            GetComponent<Collider>().enabled = false;
            resource.Increase(collectableData.increaseRate);
            OnCollected?.Invoke();
            MoveUp();
            LevelController.GainedCoin += collectableData.increaseRate;
        }
    }
}