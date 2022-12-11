using System;
using System.Collections;
using System.Collections.Generic;
using Statics;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject bossHealthBar;
    
    private void OnEnable()
    {
        StaticEvents.OnArrivedFinish += EnableBossBar;
        StaticEvents.OnBossDefeated += DisableBossBar;
    }

    public void EnableBossBar()
    {
        bossHealthBar.SetActive(true);
    }

    public void DisableBossBar()
    {
        bossHealthBar.SetActive(false);
    }

    private void OnDisable()
    {
        StaticEvents.OnArrivedFinish -= EnableBossBar;
        StaticEvents.OnBossDefeated -= DisableBossBar;
    }
}