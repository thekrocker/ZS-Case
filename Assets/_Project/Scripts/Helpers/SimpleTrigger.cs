using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleTrigger : MonoBehaviour
{
    public string Tag;

    public UnityEvent Trigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tag)) Trigger?.Invoke();
    }
}
