using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.EventArgs;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Economy/New Resource")]
public class Resource : ScriptableObject
{
    [Title("Save IDS")]
    public int InitialID;
    public int CurrentID;
    
    [Title("General Properties")] [SerializeField]
    private int defaultInitialAmount = 100;

    [SerializeField] private int initialAmount;
    [SerializeField] private int currentAmount;
    [SerializeField] private bool shouldSaveInitial;

    [Title("Clamp Values")] [SerializeField]
    private int min = 0;

    [SerializeField] private int max = Int32.MaxValue;


    public EventHandler<ResourceArgs> OnValueChanged;

    public int CurrentAmount
    {
        get => currentAmount;
        set
        {
            currentAmount = Mathf.Clamp(value, min, Max);

            OnValueChanged?.Invoke(this, new ResourceArgs()
            {
                Initial = InitialAmount,
                Current = currentAmount,
                Max = Max
            });

            SaveCurrent();
            SaveInitial();
        }
    }

    public int InitialAmount
    {
        get => initialAmount;
        set
        {
            initialAmount = value;
            SaveInitial();
        }
    }

    public int Max
    {
        get => max;
        set => max = value;
    }

    private void SaveInitial()
    {
        if (shouldSaveInitial)
        {
            PlayerPrefs.SetInt($"{InitialID}", InitialAmount);
        }
    }

    public void LoadInitialAsCurrent()
    {
        InitialAmount = PlayerPrefs.GetInt($"{CurrentID}", defaultInitialAmount);
    }

    public void LoadInitial()
    {
        InitialAmount = PlayerPrefs.GetInt($"{InitialID}", defaultInitialAmount);
    }

    private void SaveCurrent()
    {
        PlayerPrefs.SetInt($"{CurrentID}", CurrentAmount);
    }

    public void Increase(int amount = 1) => CurrentAmount += amount;

    public void Decrease(int amount = 1) => CurrentAmount -= amount;

    public bool CanAfford(int amount) => CurrentAmount >= amount;

    public void SetCurrent(int amount) => CurrentAmount = amount;

    public void SetCurrentToInitial() => SetCurrent(InitialAmount);

    public void Upgrade(int amount)
    {
        InitialAmount += amount;
        SetCurrentToInitial();
    }
    
    [Button("Get Rnd ID")]
    private void SetRandomID()
    {
        CurrentID = Random.Range(0, Int32.MaxValue);
        InitialID = Random.Range(0, Int32.MaxValue);
    }
}