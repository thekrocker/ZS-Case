using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

namespace Manager
{
    public class ParticleManager : SingletonClass.Singleton<ParticleManager>
    {
        [SerializeField] private GameObject collectParticle;
        [SerializeField] private Transform particleParent;
        
        private ObjectPooling<Poolable> _collectParticlePool;

        protected override void Awake()
        {
            base.Awake();
            CreatePools();
        }

        private void CreatePools()
        {
            _collectParticlePool = new ObjectPooling<Poolable>(collectParticle, OnPullAction, OnPushAction, 1, particleParent);
        }

        private void OnPullAction(Poolable obj)
        {
            ParticleSystem[] particleSystems = obj.GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem p in particleSystems) p.Play();
        }

        private void OnPushAction(Poolable obj)
        {
        }

        public void SpawnCollectParticle(Vector3 pos)
        {
            _collectParticlePool.Pull(pos, collectParticle.transform.rotation);
        }
    }
}