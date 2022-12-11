using _Project.Scripts.UI;
using Helpers;
using Sirenix.OdinInspector;
using Statics;
using UnityEngine;

namespace Manager
{
    [DefaultExecutionOrder(-350)]
    public class UIManager : SingletonClass.Singleton<UIManager>
    {
        [Title("Panel References")] [SerializeField]
        private PersistentPanel persistentPanel;

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
            ActivatePanelVisibility();
            SetPersistentPanel(true);
        }

        private void OnEnable()
        {
            StaticEvents.OnPreGameStarted += ActivatePreGamePanel;
            StaticEvents.OnTappedToPlay += ActivateInGamePanel;
            StaticEvents.OnArrivedFinish += DisablePersistentPanel;
            StaticEvents.OnBossDefeated += ActivateEndGamePanel;
        }

        private void SetPersistentPanel(bool s)
        {
            persistentPanel.gameObject.SetActive(s);
        }

        private void ActivatePreGamePanel()
        {
            ChangePanel(preGamePanel);
            SetPersistentPanel(true);
        }

        private void ActivateInGamePanel()
        {
            ChangePanel(inGamePanel);
        }

        private void ActivateEndGamePanel()
        {
            ChangePanel(endGamePanel);
            DisablePersistentPanel();
        }

        private void DisablePersistentPanel()
        {
            SetPersistentPanel(false);
        }
        
        private void ChangePanel(BasePanel obj)
        {
            DisablePanelVisibility();
            _activePanel = obj;
            ActivatePanelVisibility();
            obj.OnPanelActivation();
        }

        public void ActivatePanelVisibility() => _activePanel.gameObject.SetActive(true);
        public void DisablePanelVisibility() => _activePanel.gameObject.SetActive(false);


        private void OnDisable()
        {
            StaticEvents.OnPreGameStarted -= ActivatePreGamePanel;
            StaticEvents.OnTappedToPlay -= ActivateInGamePanel;
            StaticEvents.OnArrivedFinish -= DisablePersistentPanel;
            StaticEvents.OnBossDefeated -= ActivateEndGamePanel;
        }
    }
}