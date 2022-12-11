using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.EventArgs;
using Helpers;
using Statics;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private Resource diamond;
        [SerializeField] private Transform barPanel;
        [SerializeField] private Image fill;


        private void Start()
        {
            SetStackBar(diamond.CurrentAmount, diamond.Max);
        }

        private void OnEnable()
        {
            diamond.OnValueChanged += SetStackBar;
            StaticEvents.OnPreGameStarted += DisableBar;
            StaticEvents.OnTappedToPlay += EnableBar;
        }

        private void EnableBar()
        {
            barPanel.gameObject.SetActive(true);
        }

        private void DisableBar()
        {
            barPanel.gameObject.SetActive(false);
        }

        private void SetStackBar(object sender, ResourceArgs e)
        {
            SetStackBar(e.Current, e.Max);
        }

        private void SetStackBar(float amount, float maxValue)
        {
            float current = amount;
            float max = maxValue;
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
            StaticEvents.OnPreGameStarted -= DisableBar;
            StaticEvents.OnTappedToPlay -= EnableBar;
        }
    }
}