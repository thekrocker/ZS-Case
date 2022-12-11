using System;
using _Project.Scriptable_Objects.So_Scripts;
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
        [SerializeField] private CollectableEconomySo collectableData;
        

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
            resource.Increase(collectableData.increaseRate);
            OnCollected?.Invoke();
            //ScaleDown();
            MoveUp();
        }

        private float _tweenDuration = .3f;
        private void ScaleDown()
        {
            transform.DOScale(Vector3.zero, _tweenDuration).SetEase(Ease.Flash);
        }

        private void MoveUp()
        {
            Sequence seq = DOTween.Sequence();
            seq.AppendCallback(ScaleDown);
            seq.Append(transform.DOMoveY(transform.position.y + 6f, _tweenDuration).SetEase(Ease.Linear));
            seq.OnComplete(() => gameObject.SetActive(false));
        }

        public void Trigger(TriggerDetector detector)
        {
            Collect();
        }
    }
}