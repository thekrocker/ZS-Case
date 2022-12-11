using System;
using UnityEngine;

namespace Helpers
{
    public class ScaleUpper : MonoBehaviour
    {
        private void OnEnable()
        {
            transform.ScaleUp(Vector3.one, .3f);
        }
    }
}