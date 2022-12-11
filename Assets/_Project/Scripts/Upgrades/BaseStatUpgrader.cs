using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scriptable_Objects.So_Scripts;
using UnityEngine;

public abstract class BaseStatUpgrader : MonoBehaviour
{
    [SerializeField] protected StatUpgradeData upgradeData;

    private void OnEnable()
    {
        upgradeData.OnUpgradeAvailable += Upgrade;
    }

    private void OnDisable()
    {
        upgradeData.OnUpgradeAvailable -= Upgrade;
    }

    public abstract void Upgrade(float amount);
}
