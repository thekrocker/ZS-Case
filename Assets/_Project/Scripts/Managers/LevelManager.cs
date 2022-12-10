using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using Statics;
using UnityEngine;

[DefaultExecutionOrder(-355)]
public class LevelManager : SingletonClass.Singleton<LevelManager>
{
    [SerializeField] private List<LevelController> allLevels;
    public int CurrentLevelIdx { get; set; }
    public LevelController CurrentLevelController { get; private set; }

    
    private void OnEnable()
    {
        StaticEvents.OnNextButtonClicked += SpawnNextLevel;
    }

    private void Start()
    {
        SpawnLevel();
    }

    private void SpawnNextLevel()
    {
        if (CurrentLevelController != null) Destroy(CurrentLevelController.gameObject);
        IncreaseLevelIdx();
        SpawnLevel();
    }

    private void IncreaseLevelIdx() => CurrentLevelIdx++;

    private void SpawnLevel()
    {
        CurrentLevelController = Instantiate(GetCurrentLevelData());
        StaticEvents.OnPreGameStarted?.Invoke();
        StaticEvents.OnLevelChanged?.Invoke(CurrentLevelIdx + 1); // Instead of starting idx from 1, i just basically send +1 of current level to set text
    }

    private LevelController GetCurrentLevelData() => allLevels[CurrentLevelIdx % allLevels.Count]; // Loop

    private void OnDisable()
    {
        StaticEvents.OnNextButtonClicked -= SpawnNextLevel;
    }
}