using System;
using Player;
using UnityEngine;

namespace Kirill.ScriptPlaces
{
    public class ScriptRun : MonoBehaviour
    {
        [SerializeField] private bool _isStartRun;
        [SerializeField] private float _direction;
        
        public static bool IsScriptRun { get; set; }

        private void Start()
        {
            IsScriptRun = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                IsScriptRun = _isStartRun;
                PlayerMovement.Instance.CanMove = !_isStartRun;
            }
        }

        private void FixedUpdate()
        {
            if (IsScriptRun)
            {
                PlayerMovement.Instance.Move(new Vector2(_direction, 0));
            }
        }
    }
}