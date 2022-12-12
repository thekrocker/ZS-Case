using System;
using Statics;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class InGamePanel : BasePanel
    {

        [SerializeField] private GameObject tapToAttackPanel;
        
        private void OnEnable()
        {
            StaticEvents.OnArrivedFinish += ActivatePanel;
            StaticEvents.OnBossStageEnded += DisablePanel;
        }

        private void ActivatePanel()
        {
            tapToAttackPanel.SetActive(true);
        }
        
        private void DisablePanel(bool s)
        {
            tapToAttackPanel.SetActive(false);
        }


        private void OnDisable()
        {
            StaticEvents.OnArrivedFinish -= ActivatePanel;
            StaticEvents.OnBossStageEnded -= DisablePanel;
        }

        public override void OnPanelActivation()
        {
            base.OnPanelActivation();
        }
    }
}