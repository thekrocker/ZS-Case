using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Statics;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject bossHealthBar;
    [SerializeField] private GameObject preGameCam;
    [SerializeField] private GameObject inGameCam;
    [SerializeField] private GameObject endGameCam;

    private Camera _cam;
    private float _blendTime;
    private WaitForSeconds _blendInSeconds;

    public static int GainedCoin;
    private void Awake()
    {
        _cam = Camera.main;
        _blendTime = _cam.GetComponent<CinemachineBrain>().m_DefaultBlend.BlendTime;
        _blendInSeconds = new WaitForSeconds(_blendTime);
        GainedCoin = 0;
    }

    private void Start()
    {
        SetPreGameCamera();
    }

    private void OnEnable()
    {
        StaticEvents.OnTappedToPlay += SetInGameCamera;
        StaticEvents.OnArrivedFinish += EnableBossBar;
        StaticEvents.OnBossDefeated += DisableBossBar;
        StaticEvents.OnBossStageEnded += SetEndGameCamera;
    }

    private void SetPreGameCamera()
    {
        endGameCam.SetActive(false);
        inGameCam.SetActive(false);
        preGameCam.SetActive(true);
    }

    private void SetInGameCamera()
    {
        StartCoroutine(IEDelay());

        IEnumerator IEDelay()
        {
            inGameCam.SetActive(true);
            yield return _blendInSeconds;
            StaticEvents.OnInGameCamBlent?.Invoke();
        }
    }

    private void SetEndGameCamera(bool s)
    {
        float offset = 1f;
        WaitForSeconds offsetInSec = new WaitForSeconds(offset);
        WaitForSeconds blendAndOffset = new WaitForSeconds(offset + _blendTime);
        StartCoroutine(IEDelay());

        IEnumerator IEDelay()
        {
            yield return offsetInSec;
            endGameCam.SetActive(true);
            yield return blendAndOffset;
            StaticEvents.OnEndGameCamBlent?.Invoke(s);
        }
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
        StaticEvents.OnPreGameStarted -= SetPreGameCamera;
        StaticEvents.OnTappedToPlay -= SetInGameCamera;
        StaticEvents.OnArrivedFinish -= EnableBossBar;
        StaticEvents.OnBossDefeated -= DisableBossBar;
        StaticEvents.OnBossStageEnded -= SetEndGameCamera;
    }
}