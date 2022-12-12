using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.EventArgs;
using Helpers;
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
    [SerializeField] private Transform currencyGoldPanel;
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
        SetLevelTextVisibility(true);
    }

    private void SetCurrencyGoldUI(object sender, ResourceArgs e)
    {
        SetText(currencyGoldText, e.Current);
        currencyGoldPanel.PulseSingle(Vector3.one, Vector3.one * 1.15f, .1f, 0f);
    }

    private void SetDiamondUI(object sender, ResourceArgs e)
    {
        SetText(diamondText, e.Current);
    }

    private void SetLevelText(int obj)
    {
        SetText(levelText, obj, "LEVEL ");
    }

    public void SetLevelTextVisibility(bool s)
    {
        levelText.gameObject.SetActive(s);
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
