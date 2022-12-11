using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.EventArgs;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Economy/New Resource")]
public class Resource : ScriptableObject
{
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
            PlayerPrefs.SetInt(nameof(InitialAmount), InitialAmount);
        }
    }

    public void LoadInitialAsCurrent()
    {
        InitialAmount = PlayerPrefs.GetInt(nameof(CurrentAmount), defaultInitialAmount);
    }

    public void LoadInitial()
    {
        InitialAmount = PlayerPrefs.GetInt(nameof(InitialAmount), defaultInitialAmount);
    }

    private void SaveCurrent()
    {
        PlayerPrefs.SetInt(nameof(CurrentAmount), CurrentAmount);
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
}