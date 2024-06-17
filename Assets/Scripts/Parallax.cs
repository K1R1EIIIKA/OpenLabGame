using System;
using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField][Range(-1f, 1f)] private float _parallaxStrength = 0.1f;
    [SerializeField] private bool _isVertical;

    private Vector3 _lastPosition;

    private void Start()
    {
        _lastPosition = _target.position;
    }

    private void Update()
    {
        Vector3 delta = _target.position - _lastPosition;
        Vector3 parallax = new Vector3(delta.x * _parallaxStrength, delta.y * _parallaxStrength, 0);
        transform.position += _isVertical ? new Vector3(parallax.y, parallax.x, 0) : parallax;

        _lastPosition = _target.position;
    }
}
