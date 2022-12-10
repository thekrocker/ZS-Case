using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Collectable
{
    public class Diamond : MonoBehaviour, ICollectable
    {
        [SerializeField] private Resource diamondStackResource;
        
        public void Collect(Collector collector)
        {
            // Set collect effects here..
            diamondStackResource.Increase();
        }
    }
}

