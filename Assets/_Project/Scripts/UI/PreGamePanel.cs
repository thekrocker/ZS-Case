using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.UI;
using Statics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PreGamePanel : BasePanel
{
    [SerializeField] private Button panelButton;

    public void AddListener(UnityAction action) => panelButton.onClick.AddListener(action);
    public void RemoveListener(UnityAction action) => panelButton.onClick.RemoveListener(action);

    private void OnEnable()
    {
        AddListener(OnTapPlay);
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