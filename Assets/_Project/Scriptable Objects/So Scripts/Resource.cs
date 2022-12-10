using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.EventArgs;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Economy/New Resource")]
public class Resource : ScriptableObject
{
    [Title("General Properties")]
    [SerializeField] private int initialAmount;
    [ReadOnly] [SerializeField] private int currentAmount;
    
    [Title("Clamp Values")]
    [SerializeField] private int min = 0;
    [SerializeField] private int max = Int32.MaxValue;

    
    public EventHandler<ResourceArgs> OnValueChanged;
    
    public int CurrentAmount
    {
        get => currentAmount;
        set
        {
            currentAmount = Mathf.Clamp(value, min, max);
            
            OnValueChanged?.Invoke(this, new ResourceArgs() {
                Initial = initialAmount,
                Current = currentAmount,
                Max = max
            });
        }
    }

    private void OnValidate()
    {
        SetCurrent(initialAmount);
    }

    public void Increase(int amount = 1) => CurrentAmount += amount;

    public void Decrease(int amount = 1) => CurrentAmount -= amount;

    public bool CanAfford(int amount) => CurrentAmount >= amount;

    public void SetCurrent(int amount) => CurrentAmount = amount;

    public void SetCurrentToInitial() => SetCurrent(initialAmount);
}
