using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BossTriggerPositionSetter : MonoBehaviour
{
    [SerializeField] private Transform bossTransform;
    [SerializeField] private float offset;

    void Awake()
    {
        Set();
    }

    [Button("Set Position")]
    private void Set()
    {
        transform.position =
            new Vector3(transform.position.x, transform.position.y, bossTransform.position.z + offset);
    }
    
}
