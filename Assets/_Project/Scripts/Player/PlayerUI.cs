using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.EventArgs;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private Resource diamond;
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
        }

        private void OnDisable()
        {
            diamond.OnValueChanged -= SetStackBar;
        }
    }
}