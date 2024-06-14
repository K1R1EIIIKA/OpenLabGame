using Cinemachine;
using System.Collections;
using System.Collections.Generic;
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
