using System.Collections;
using Player;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private PlayerMovement _playerMovementScript;

    [Header("Flip Rotation Stats")]
    [SerializeField] private float _flipRotationTime = 0.5f;

    private Coroutine _turnCoroutine;

    [SerializeField] private float _cooldownRotation = 4f;
    private float _lastRotation;

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
        if (_turnCoroutine == null)
        {
            _turnCoroutine = StartCoroutine(FlipYLerp());
        }
    }

    private IEnumerator FlipYLerp()
    {
        if (Time.time - _lastRotation >= _cooldownRotation)
        {
            _lastRotation = Time.time;

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
        _turnCoroutine = null;
    }

    private float DeterminendRotation()
    {
        _isFacingRight = !_isFacingRight;

        return _isFacingRight ? 180f : 0f;
    }
}

