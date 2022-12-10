using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.UI;
using Helpers;
using Sirenix.OdinInspector;
using Statics;
using UnityEngine;

public class UIManager : SingletonClass.Singleton<UIManager>
{
    [Title("Panel References")]
    [SerializeField] private PreGamePanel preGamePanel;
    [SerializeField] private InGamePanel inGamePanel;
    [SerializeField] private EndGamePanel endGamePanel;

    private BasePanel _activePanel;

    protected override void Awake()
    {
        base.Awake();
        SetInitialPanel();
    }
    private void SetInitialPanel()
    {
        _activePanel = preGamePanel;
    }

    private void OnEnable()
    {
        AddPanelListeners();
    }
    
    private void OnClickPreGamePanel()
    {
        ChangePanel(inGamePanel);
    }

    private void ChangePanel(BasePanel obj)
    {
        DisablePanel(_activePanel.gameObject);
        _activePanel = obj;
        ActivatePanel(_activePanel.gameObject);
        obj.OnPanelActivation();
    }
    
    public void ActivatePanel(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void DisablePanel(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void AddPanelListeners()
    {
        preGamePanel.AddListener(OnClickPreGamePanel);
    }

    private void RemovePanelListeners()
    {
        preGamePanel.RemoveListener(OnClickPreGamePanel);
    }

    private void OnDisable()
    {
        RemovePanelListeners();
    }
    
}