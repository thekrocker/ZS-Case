using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

public class PoofParticleHandler : MonoBehaviour
{
    [SerializeField] private Transform particleSpawnPoint;
    
    public void Spawn()
    {
        ParticleManager.Instance.SpawnCollectParticle(particleSpawnPoint.position);
    }
}
