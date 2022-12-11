using System.Collections;
using System.Collections.Generic;
using Manager;
using Sirenix.OdinInspector;
using UnityEngine;

public class ParticleSpawnHandler : MonoBehaviour
{
    [HideLabel] [EnumToggleButtons]
    [SerializeField] private EParticleType type;
    
    [SerializeField] private Transform particleSpawnPoint;
    
    public void Spawn()
    {
        ParticleManager.Instance.SpawnParticleByType(type,particleSpawnPoint.position);
    }
}
