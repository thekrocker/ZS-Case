using System;
using _Project.Scripts.Interfaces;
using DG.Tweening;
using Player;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Collectable
{
    public class CollectableItem : MonoBehaviour, ITriggerable
    {
        [Title("Simulation")]
        [SerializeField] private float minRotateSpeed;
        [SerializeField] private float maxRotateSpeed;
        
        [Title("Resource Props")]
        [SerializeField] protected Resource resource;

        private float _rotateSpeed;

        public UnityEvent OnCollected;
        private void Start()
        {
            _rotateSpeed = Random.Range(minRotateSpeed, maxRotateSpeed);
        }

        private void Update()
        {
            SelfRotate();
        }

        private void SelfRotate()
        {
            transform.Rotate(0, _rotateSpeed * Time.deltaTime, 0);
        }

        public virtual void Collect()
        {
            GetComponent<Collider>().enabled = false;
            resource.Increase();
            OnCollected?.Invoke();
            ScaleDown();
        }

        private void ScaleDown()
        {
            transform.DOScale(Vector3.zero, .4f).SetEase(Ease.Flash).OnComplete(() => gameObject.SetActive(false));
        }

        public void Trigger(TriggerDetector detector)
        {
            Collect();
        }
    }
}