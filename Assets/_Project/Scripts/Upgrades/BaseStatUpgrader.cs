using System.Collections;
using System.Collections.Generic;
using _Project.Scriptable_Objects.So_Scripts;
using UnityEngine;

public abstract class BaseStatUpgrader : MonoBehaviour
{
    [SerializeField] protected StatUpgradeData upgradeData;
    
    public abstract void Upgrade();
}
