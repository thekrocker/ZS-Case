using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Helpers
{
    /// <summary>
    /// Created by @Safa Dedaekay
    /// </summary>
    public static class DoTweenExtensions
    {
        public static void PulseLoop(this Transform target, Vector3 initialScale, Vector3 targetScale,
            float duration = .3f, float delay = .3f, LoopType type = LoopType.Restart, Action OnComplete = null)
        {
            DOTween.Sequence()
                .Append(target.DOScale(targetScale, duration).SetDelay(delay))
                .Append(target.DOScale(initialScale, duration)).OnComplete(() => OnComplete?.Invoke())
                .SetLoops(-1, type);
        }

        public static void PulseSingle(this Transform target, Vector3 initialScale, Vector3 targetScale, float duration = .3f, float delay = .3f, Action completeAction = null)
        {
            DOTween.Sequence().Append(target.DOScale(targetScale, duration).SetDelay(delay)).Append(target.DOScale(initialScale, duration)).OnComplete(() => completeAction?.Invoke()).SetLink(target.gameObject);
        }

        public static void FadeImg<T>(this T img, float duration) where T : Image
        {
            img.DOFade(0f, duration);
        }

        public static void FadeText(this TextMeshProUGUI txt, float duration)
        {
            txt.DOFade(0f, duration);
        }

        public static void FadePulseText(this TextMeshProUGUI txt, float duration, float delay, float initialAlpha = 1f,
            float targetAlpha = 0f)
        {
            DOTween.Sequence().Append(txt.DOFade(targetAlpha, duration).SetDelay(delay))
                .Append(txt.DOFade(initialAlpha, duration)).SetLoops(-1, LoopType.Restart);
        }

        public static void PunchScaleTween(this Transform target, float punchRatio, float duration = 0,
            Ease ease = Ease.Linear, Action completeAction = null)
        {
            target.DOPunchScale(Vector3.one * punchRatio, duration)
                .SetEase(ease)
                .OnComplete(() => { completeAction?.Invoke(); });
        }


        public static void ScaleUp(this Transform original, Vector3 targetScale, float duration,
            Ease easeType = Ease.Linear)
        {
            original.localScale = Vector3.zero;
            original.DOScale(targetScale, duration).SetEase(easeType);
        }

        public static void ScaleDown(this Transform original, Vector3 targetScale, float duration,
            Ease easeType = Ease.Linear)
        {
            original.DOScale(targetScale, duration).SetEase(easeType);
        }
    }
}