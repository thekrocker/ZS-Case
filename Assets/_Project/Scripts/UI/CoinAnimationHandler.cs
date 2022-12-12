using System;
using System.Collections;
using DG.Tweening;
using Manager;
using Statics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.UI
{
    public class CoinAnimationHandler : MonoBehaviour
    {
        [SerializeField] private Transform initialPoolParent;
        [SerializeField] private float initialDelay = .5f;
        [SerializeField] private GameObject currencyObj;
        [SerializeField] private Transform targetPoint;
        [SerializeField] private Transform spawnPoint;
        [Space(10)] [SerializeField] private Transform iconPunchBody;
        [SerializeField] private Resource currencyResource;

        private const float SPAWN_OFFSET = 100f;
        private const float SPAWN_DELAY = 0.05f;
        private const int DIAMOND_AMOUNT = 15;

        private const Ease MOVEMENT_EASE = Ease.InOutSine;
        private const float OFFSET_MOVEMENT_DURATION = 0.2f;
        private const float TARGET_MOVEMENT_DURATION = 0.5f;
        private readonly Vector3 MOVEMENT_OFFSET = new Vector3(-50f, 50f, 0f);

        private const float MIN_SCALE = 0.01f;
        private const float SCALE_UP_DURATION = 0.2f;
        private const Ease SCALE_EASE = Ease.InOutBack;

        private const float PUNCH_STRENGTH = 0.25f;
        private const float PUNCH_DURATION = 0.3f;
        private const Ease PUNCH_EASE = Ease.InOutSine;

        private string _punchScaleTweenID;

        private ObjectPooling<Poolable> _coinPool;
        private void Awake()
        {
            _coinPool = new ObjectPooling<Poolable>(currencyObj, 5);
            _punchScaleTweenID = GetInstanceID() + "PunchScaleTweenID";
        }

        private void OnEnable()
        {
            CoinAnimation();
        }

        private void CoinAnimation()
        {
            float animationDuration = DIAMOND_AMOUNT * SPAWN_DELAY + OFFSET_MOVEMENT_DURATION + TARGET_MOVEMENT_DURATION + SCALE_UP_DURATION;
            WaitForSeconds delay = new WaitForSeconds(animationDuration + initialDelay);
            
            StartCoroutine(IECoinRoutine());
            IEnumerator IECoinRoutine()
            {
                StartCoroutine(CoinAnimationCoroutine(LevelController.GainedCoin));
                yield return delay;
                OnAnimationCompleted();
            }
        }

        private IEnumerator CoinAnimationCoroutine(int diamondValue)
        {
            WaitForSeconds delay = new WaitForSeconds(initialDelay);
            
            yield return delay;
            
            for (int i = 0; i < DIAMOND_AMOUNT; i++)
            {
                Vector3 spawPosition = spawnPoint.position + (Vector3)Random.insideUnitCircle * SPAWN_OFFSET;
                GameObject diamondImage = _coinPool.PullGameObject(spawPosition, Quaternion.identity);

                Vector3 defaultScale = diamondImage.transform.localScale;
                Vector3 startScale = Vector3.one * MIN_SCALE;

                diamondImage.transform.SetParent(targetPoint);
                diamondImage.transform.localScale = startScale;

                Sequence coinSequence = DOTween.Sequence();
                coinSequence.Append(diamondImage.transform.DOScale(defaultScale, SCALE_UP_DURATION).SetEase(SCALE_EASE))
                    .Append(diamondImage.transform
                        .DOMove(diamondImage.transform.position - MOVEMENT_OFFSET, OFFSET_MOVEMENT_DURATION)
                        .SetEase(MOVEMENT_EASE))
                    .Append(diamondImage.transform.DOMove(targetPoint.position, TARGET_MOVEMENT_DURATION)
                        .SetEase(MOVEMENT_EASE)).OnComplete(() =>
                    {
                        SenBackToPool(diamondImage);
                        PunchIcon();
                    }).SetLink(diamondImage.gameObject);
                yield return new WaitForSeconds(SPAWN_DELAY);
            }

            //AddDiamondValue(remainder);
            yield return null;
        }

        private void OnAnimationCompleted()
        {
            // Push some event..
            if (GameManager.Instance.GameWin) AddValue(BossManager.Instance.BossBonusCount);
            StaticEvents.OnCoinAnimCompleted?.Invoke();
        }

        private void AddValue(int value)
        {
            currencyResource.Increase(value);
        }

        private void PunchIcon()
        {
            DOTween.Complete(_punchScaleTweenID);
            iconPunchBody.DOPunchScale(Vector3.one * PUNCH_STRENGTH, PUNCH_DURATION, 1).SetEase(PUNCH_EASE)
                .SetId(_punchScaleTweenID).SetLink(iconPunchBody.gameObject);
        }

        private void SenBackToPool(GameObject poolObject)
        {
            poolObject.SetActive(false);
        }
    }
}