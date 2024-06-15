using Cinemachine;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    [SerializeField] private CinemachineBrain _camera;

    public void DisableVirtualCamera()
    {
        _camera.enabled = false;
    }

    public void EnableVirtualCamera()
    {
        _camera.enabled = true;
    }
}