using UnityEngine;

public class CanvasCameraLook : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    void LateUpdate()
    {
        transform.forward = _camera.transform.forward;
    }
}