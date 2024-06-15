using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Kirill.Npc
{
    public class NpcEmotion : MonoBehaviour
    {
        [SerializeField] private GameObject _hintCanvas;
        [SerializeField] private GameObject _emotionCloud;
        [SerializeField] private SpriteRenderer _emotionImage;
        [SerializeField] private List<EmotionSO> _emotions;
        [SerializeField] private float _lifeTime = 3f;

        private bool _isTriggered;
        private bool _isCooldown;
        private List<SpriteRenderer> _cloudRenderers;

        private void Awake()
        {
            _cloudRenderers = new List<SpriteRenderer>(_emotionCloud.GetComponentsInChildren<SpriteRenderer>());

            foreach (var renderer in _cloudRenderers)
            {
                var color = renderer.color;
                color.a = 0;
                renderer.color = color;
            }

            _emotionCloud.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(_isCooldown);
            if (other.CompareTag("Player") && !_isCooldown)
            {
                _hintCanvas.SetActive(true);
                _isTriggered = true;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            Debug.Log(_isCooldown);
            if (other.CompareTag("Player") && !_isCooldown)
            {
                _hintCanvas.SetActive(true);
                _isTriggered = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _hintCanvas.SetActive(false);
                _isTriggered = false;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && _isTriggered && !_isCooldown)
            {
                _isCooldown = true;
                ShowCloud();
                _hintCanvas.SetActive(false);
            }
        }

        private void ShowCloud()
        {
            _emotionCloud.SetActive(true);

            var randomEmotion = _emotions[Random.Range(0, _emotions.Count)].Emotion;
            SetEmotion(randomEmotion);
            foreach (var renderer in _cloudRenderers)
            {
                renderer.DOFade(1, 0.75f);
            }
            
            DOVirtual.DelayedCall(_lifeTime, () => { HideCloud(); });
        }

        private void HideCloud()
        {
            DOVirtual.DelayedCall(0.75f, () => { _isCooldown = false; });
            foreach (var renderer in _cloudRenderers)
            {
                renderer.DOFade(0, 0.75f).OnComplete(() => { _emotionCloud.SetActive(false); });
            }
        }

        private void SetEmotion(Emotion emotion)
        {
            var emotionObject = _emotions.Find(e => e.Emotion == emotion);
            _emotionImage.sprite = emotionObject.Sprite;
        }
    }
}