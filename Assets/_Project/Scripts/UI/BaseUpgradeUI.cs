using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseUpgradeUI : MonoBehaviour
{
    [SerializeField] private Button clickButton;
    [SerializeField] protected TextMeshProUGUI costText;
    [SerializeField] protected TextMeshProUGUI levelText;
    [SerializeField] protected Image upgradeImg;

    protected virtual void Start()
    {
    }

    protected virtual void OnEnable()
    {
        clickButton.onClick.AddListener(OnClickButton);
    }

    private bool _isTweening;
    protected virtual void OnClickButton()
    {
        if (_isTweening) return;
        _isTweening = true;
        Sequence seq = DOTween.Sequence();
        seq.Append(clickButton.transform.DOScale(Vector3.one * 1.2f,.2f));
        seq.Append(clickButton.transform.DOScale(Vector3.one, .2f));
        seq.OnComplete(() => _isTweening = false);

    }

    protected abstract void SetCostText(int amount);
    protected abstract void SetLevelText(int amount);
    protected abstract void SetUpgradeSprite();

    private void OnDisable()
    {
        clickButton.onClick.RemoveListener(OnClickButton);

    }
}
