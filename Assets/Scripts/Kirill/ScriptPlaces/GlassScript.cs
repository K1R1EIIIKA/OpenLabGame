using System.Collections.Generic;
using DG.Tweening;
using Kirill.Audio;
using Player;
using UnityEngine;

namespace Kirill.ScriptPlaces
{
    public class GlassScript : MonoBehaviour
    {
        [SerializeField] private GameObject _hintCanvas;
        [SerializeField] private GameObject _rockPrefab;
        [SerializeField] private Transform _player;
        [SerializeField] private Vector2 _offset;
        [SerializeField] private Vector2 _force;
        [SerializeField] private List<GameObject> _objectsToEnable;
        [SerializeField] private List<GameObject> _objectsToDisable;
        [SerializeField] private Animator _cameraShake;

        private bool _isTriggered;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerMovement.Instance.CanMove = false;
                _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                _player.GetComponent<PlayerMovement>().animator.SetBool("IsMove", false);
                AudioManager.Instance.Stop("Player Move");
                _hintCanvas.SetActive(true);
                _isTriggered = true;
            }
        }
        
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _hintCanvas.SetActive(false);
                _isTriggered = false;
            }
        }
        
        private void Update()
        {
            if (_isTriggered && Input.GetKeyDown(KeyCode.E))
            {
                StartCutscene();
            }
        }

        private void StartCutscene()
        {
            var rock = Instantiate(_rockPrefab, _player.position + (Vector3)_offset, Quaternion.identity);
            rock.GetComponent<Rigidbody2D>().AddForce(_force, ForceMode2D.Impulse);
            
            _cameraShake.enabled = true;
            DOVirtual.DelayedCall(1.5f, () => { _cameraShake.enabled = false; });
            DOVirtual.DelayedCall(2f, EnableObjects);
        }

        private void EnableObjects()
        {
            
            foreach (var obj in _objectsToEnable)
            {
                obj.SetActive(true);
            }
            
            foreach (var obj in _objectsToDisable)
            {
                obj.SetActive(false);
            }
        }
    }
}