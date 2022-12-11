using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class BaseUpgradeData : ScriptableObject
{
    [Title("Func")]
    public int cost;
    public int level = 1;
    
    [Title("Visual")]
    public Sprite sprite;
    public string upgradeName;

    public Action<int> OnCostChanged;
    public Action<int> OnLevelChanged;
    public int Cost
    {
        get => cost;
        set
        {
            cost = value;
            OnCostChanged?.Invoke(cost);
            SaveStat(Cost);
        }
    }

    public int Level
    {
        get => level;
        set
        {
            level = value;
            OnLevelChanged?.Invoke(level);
            SaveStat(Level);
        }
    }

    public void SaveStat(int stat)
    {
        PlayerPrefs.SetInt(nameof(stat), stat);
    }

    public void LoadStats()
    {
        Level = PlayerPrefs.GetInt(nameof(Level), 1);
        Cost = PlayerPrefs.GetInt(nameof(Cost), cost);
    }
}
