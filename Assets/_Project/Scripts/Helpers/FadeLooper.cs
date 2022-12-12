using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using TMPro;
using UnityEngine;

public class FadeLooper : MonoBehaviour
{
    private TextMeshProUGUI _txt;

    private void Awake()
    {
        _txt = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
       _txt.FadePulseText(.5f, 0f);
    }


}
