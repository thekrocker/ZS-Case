using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

namespace Manager
{
    public enum EParticleType
    {
        HIT_PARTICLE,
        DIAMOND_PARTICLE,
        GOLD_PARTICLE
    }
    
    public class ParticleManager : SingletonClass.Singleton<ParticleManager>
    {
        [SerializeField] private GameObject hitParticle;
        [SerializeField] private GameObject diamondParticle;
        [SerializeField] private GameObject goldParticle;
        [SerializeField] private Transform particleParent;
        
        private ObjectPooling<Poolable> _hitParticlePool;
        private ObjectPooling<Poolable> _diamondParticlePool;
        private ObjectPooling<Poolable> _goldParticlePool;

        protected override void Awake()
        {
            base.Awake();
            CreatePools();
        }

        private void CreatePools()
        {
            _hitParticlePool = new ObjectPooling<Poolable>(hitParticle, OnPullAction, OnPushAction, 1, particleParent);
            _diamondParticlePool = new ObjectPooling<Poolable>(diamondParticle, OnPullAction, OnPushAction, 1, particleParent);
            _goldParticlePool = new ObjectPooling<Poolable>(goldParticle, OnPullAction, OnPushAction, 1, particleParent);
        }

        private void OnPullAction(Poolable obj)
        {
            ParticleSystem[] particleSystems = obj.GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem p in particleSystems) p.Play();
        }

        private void OnPushAction(Poolable obj)
        {
        }

        public void SpawnParticleByType(EParticleType pType, Vector3 pos)
        {
            // I dont like the switch way while spawning. Since its against Open-Close Principle. 
            // Since its a pool i cant directly give prefab reference to instantiate in somewhere, i somehow need to check from dictionary or smth. Because need to existing one from pool. So for sake of hyper-casual project
            // I will make that simple.

            switch (pType)
            {
                case EParticleType.HIT_PARTICLE:
                    _hitParticlePool.Pull(pos, hitParticle.transform.rotation);
                    break;
                case EParticleType.DIAMOND_PARTICLE:
                    _diamondParticlePool.Pull(pos, hitParticle.transform.rotation);
                    break;
                case EParticleType.GOLD_PARTICLE:
                    _goldParticlePool.Pull(pos, hitParticle.transform.rotation);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pType), pType, null);
            }
        }
    }
}