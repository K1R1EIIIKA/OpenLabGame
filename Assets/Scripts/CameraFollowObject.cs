using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private PlayerMovement _playerMovementScript;

    [Header("Flip Rotation Stats")]
    [SerializeField] private float _flipRotationTime = 0.5f;

    private Coroutine _turnCoroutine;

    [SerializeField] private float coolDownCameraRotation = 4f;
    private float timeLast;


    private bool _isFacingRight;

    private void Start()
    {
        _isFacingRight = _playerMovementScript.GetIsFacingDirection();
    }

    private void FixedUpdate()
    {
        transform.position = _playerTransform.position;
    }

    public void CallTurn()
    {
        _turnCoroutine = StartCoroutine(FlipYLerp());
    }
    private IEnumerator FlipYLerp()
    {        
        if(Time.time - timeLast < coolDownCameraRotation)
        {
            timeLast = Time.time;
            float startRotation = transform.localEulerAngles.y;
            float endRotationAmount = DeterminendRotation();
            float yRotation = 0f;

            float elapseTime = 0f;
            while (elapseTime < _flipRotationTime)
            {
                elapseTime += Time.deltaTime;

                yRotation = Mathf.Lerp(startRotation, endRotationAmount, (elapseTime / _flipRotationTime));
                transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

                yield return null;
            }
        }
        else
        {
            yield return null;
        }
        
    }



    private float DeterminendRotation()
    {
        _isFacingRight = !_isFacingRight;
        
        if (_isFacingRight )
        {
            return 180f;
        }
        else
        {
            return 0f;
        }
    }

}
