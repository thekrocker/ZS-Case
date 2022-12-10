using Statics;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class InGamePanel : BasePanel
    {
        [SerializeField] private Resource diamondResource;
        [SerializeField] private Resource currencyGoldResource;

        public override void OnPanelActivation()
        {
            base.OnPanelActivation();
            StaticEvents.OnGameStarted?.Invoke();
        }
    }
}