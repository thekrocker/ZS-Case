using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

public class PoofParticleHandler : MonoBehaviour
{
    public void Spawn()
    {
        ParticleManager.Instance.SpawnCollectParticle(transform.position);
    }
}
