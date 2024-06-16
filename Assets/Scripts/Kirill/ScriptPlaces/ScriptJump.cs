using System;
using Player;
using UnityEngine;

namespace Kirill.ScriptPlaces
{
    public class ScriptJump : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerMovement.Instance.ScriptJump(_jumpForce);
            }
        }
    }
}