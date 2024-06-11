using System;
using UnityEngine;

namespace Kirill
{
    public class DoorLogic : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _hintCanvas;
        [SerializeField] private GameObject _player;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _hintCanvas.SetActive(true);
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _hintCanvas.SetActive(false);
            }
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && _hintCanvas.activeSelf)
            {
                _player.transform.position = _target.position;
                _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }
}