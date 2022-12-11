using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class BaseUpgradeData : ScriptableObject
{
    [Title("Func")] 
    public int costId;
    public int levelId;
    
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
            SaveStat(costId, Cost);
        }
    }

    public int Level
    {
        get => level;
        set
        {
            level = value;
            OnLevelChanged?.Invoke(level);
            SaveStat(levelId,Level);
        }
    }

    public void SaveStat(int id,int stat)
    {
        PlayerPrefs.SetInt($"{id}", stat);
    }

    protected void IncreaseLevel()
    {
        Level++;
    }

    protected void IncreaseCost()
    {
        Cost *= 2;
    }

    public void LoadStats()
    {
        Level = PlayerPrefs.GetInt($"{levelId}", 1);
        Cost = PlayerPrefs.GetInt($"{costId}", cost);
    }

    [Button("Get Rnd ID")]
    private void SetRandomID()
    {
        levelId = Random.Range(0, Int32.MaxValue);
        costId = Random.Range(0, Int32.MaxValue);
    }
}
