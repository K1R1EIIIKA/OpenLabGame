using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Kirill
{
    public class DoorLogic : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _player;
        [SerializeField] private Image _loadingCanvas;
        
        [Header("Hint")]
        [SerializeField] private GameObject _hintCanvas;
        [SerializeField] private bool _isHintNeeded;
        
        private static bool _isCooldown;

        private void Start()
        {
            _isCooldown = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (_isHintNeeded)
                    _hintCanvas.SetActive(true);
                else
                    OpenDoor();
                    
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
            if (Input.GetKeyDown(KeyCode.E) && _hintCanvas.activeSelf && !_isCooldown)
            {
                OpenDoor();
            }
        }

        private void OpenDoor()
        {
            _isCooldown = true;
            _loadingCanvas.gameObject.SetActive(true);

            _loadingCanvas.DOFade(0, 0);
            _loadingCanvas.DOFade(1, 1).OnComplete(() =>
            {
                _player.transform.position = _target.position;
                _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                DOVirtual.DelayedCall(1,
                    () =>
                    {
                        _loadingCanvas.DOFade(0, 1).OnComplete(() =>
                        {
                            _loadingCanvas.gameObject.SetActive(false); 
                            _isCooldown = false;
                        });
                    });
            });
        }
    }
}