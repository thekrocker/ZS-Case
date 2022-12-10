using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.EventArgs;
using Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private Resource diamond;
        [SerializeField] private Transform barPanel;
        [SerializeField] private Image fill;
        

        private void OnEnable()
        {
            diamond.OnValueChanged += SetStackBar;
        }

        private void SetStackBar(object sender, ResourceArgs e)
        {
            float current = e.Current;
            float max = e.Max;
            fill.fillAmount = current / max;
            PulsePanel();
        }

        private void PulsePanel()
        {
            barPanel.PulseSingle(Vector3.one, Vector3.one * 1.3f, .2f, 0f);
        }

        private void OnDisable()
        {
            diamond.OnValueChanged -= SetStackBar;
        }
    }
}