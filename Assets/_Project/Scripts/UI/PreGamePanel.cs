using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.UI;
using Helpers;
using Statics;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PreGamePanel : BasePanel
{
    [SerializeField] private Button panelButton;
    [SerializeField] private TextMeshProUGUI tapToStartText;

    public void AddListener(UnityAction action) => panelButton.onClick.AddListener(action);
    public void RemoveListener(UnityAction action) => panelButton.onClick.RemoveListener(action);

    private void OnEnable()
    {
        AddListener(OnTapPlay);
        PulseText();
    }

    private void PulseText()
    {
        tapToStartText.transform.PulseLoop(Vector3.one, Vector3.one * 1.3f, .3f, 0f);
    }

    private void OnTapPlay()
    {
        StaticEvents.OnTappedToPlay?.Invoke();
    }

    public override void OnPanelActivation()
    {
        base.OnPanelActivation();
    }

    private void OnDisable()
    {
        RemoveListener(OnTapPlay);
    }
}