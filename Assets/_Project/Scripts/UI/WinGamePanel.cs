using System.Collections;
using Manager;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class WinGamePanel : EndGamePanel
    {
        [SerializeField] private TextMeshProUGUI bossBonusText;
        [SerializeField] private GameObject bonusArea;

        protected override void OnEnable()
        {
            base.OnEnable();
            ActivateBonusArea();
        }
        
        private void ActivateBonusArea()
        {
            StartCoroutine(Delay());

            IEnumerator Delay()
            {
                yield return new WaitForSeconds(.3f);
                bossBonusText.text = $"+{BossManager.Instance.BossBonusCount}";
                bonusArea.SetActive(true);
            }
 
        }
        
        private void DisableBonusArea()
        {
            bonusArea.SetActive(false);
        }
    }
}