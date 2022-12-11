using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Interfaces;
using Player;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour, ITriggerable
{
    [SerializeField] private float rotateSpeed = 300f;
    [SerializeField] private Transform model;
    [SerializeField] private Resource diamond;

    public UnityEvent OnHit;
    private void Update()
    {
        SelfRotate();
    }
    
    private void SelfRotate()
    {
        model.Rotate(0, 0f, rotateSpeed * Time.deltaTime);
    }
    
    public void Hit()
    {
        diamond.Decrease();
        OnHit.Invoke();
        gameObject.SetActive(false);
    }

    public void Trigger(TriggerDetector detector)
    {
        Hit();
    }
}
