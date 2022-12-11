using System;
using System.Collections;
using System.Collections.Generic;
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

    protected virtual void OnClickButton()
    {
    }

    protected abstract void SetCostText(int amount);
    protected abstract void SetLevelText(int amount);
    protected abstract void SetUpgradeSprite();
}
