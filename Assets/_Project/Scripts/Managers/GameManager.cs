using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

namespace Manager
{
    [DefaultExecutionOrder(-360)]
    public class GameManager : SingletonClass.Singleton<GameManager>
    {
        [SerializeField] private BoxCollider platformTemplate;
        public float GetPlatformLength() => platformTemplate.size.z;
        public float GetPlatformWidth() => platformTemplate.size.x;
    }
}