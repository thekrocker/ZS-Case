using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.EventArgs;
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
        SetCurrencyGoldUI();
        SetDiamondUI();
    }

    private void OnEnable()
    {
        diamondResource.OnValueChanged += SetDiamondUI;
        currencyGoldResource.OnValueChanged += SetCurrencyGoldUI;
        StaticEvents.OnLevelChanged += SetLevelText;
    }

    private void SetCurrencyGoldUI(object sender, ResourceArgs e)
    {
        SetText(currencyGoldText, e.Current);
    }

    private void SetDiamondUI(object sender, ResourceArgs e)
    {
        SetText(diamondText, e.Current);

    }

    private void SetLevelText(int obj)
    {
        SetText(levelText, obj, "LEVEL ");
    }

    private void SetCurrencyGoldUI()
    {
        SetText(currencyGoldText, currencyGoldResource.CurrentAmount);
    }
    private void SetDiamondUI()
    {
        SetText(diamondText, diamondResource.CurrentAmount);
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
