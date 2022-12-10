using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Statics;
using TMPro;
using UnityEngine;

public class PersistentPanel : MonoBehaviour
{
    [Title("Resource Refs")]
    [SerializeField] private Resource diamondResource;
    [SerializeField] private Resource currencyGoldResource;

    [Title("UI Refs")]
    [SerializeField] private TextMeshProUGUI diamondText;
    [SerializeField] private TextMeshProUGUI currencyGoldText;
    [SerializeField] private TextMeshProUGUI levelText;
    
    
    private void Start()
    {
        SetCurrencyGoldUI(currencyGoldResource.CurrentAmount);
        SetDiamondUI(diamondResource.CurrentAmount);
    }

    private void OnEnable()
    {
        diamondResource.OnValueChanged += SetDiamondUI;
        currencyGoldResource.OnValueChanged += SetCurrencyGoldUI;
        StaticEvents.OnLevelChanged += SetLevelText;
    }

    private void SetLevelText(int obj)
    {
        SetText(levelText, obj, "LEVEL ");
    }

    private void SetCurrencyGoldUI(int amount)
    {
        SetText(currencyGoldText, amount);
    }
    private void SetDiamondUI(int amount)
    {
        SetText(diamondText, amount);
    }
    
    private void SetText(TextMeshProUGUI txt, int amount, string prefix = "")
    {
        txt.text = $"{prefix}{amount}";
    }

    private void OnDisable()
    {
        diamondResource.OnValueChanged -= SetDiamondUI;
        currencyGoldResource.OnValueChanged -= SetCurrencyGoldUI; 
        StaticEvents.OnLevelChanged -= SetLevelText;
    }
}
