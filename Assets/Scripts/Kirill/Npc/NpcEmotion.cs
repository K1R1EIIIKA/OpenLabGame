using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Kirill.Npc
{
    public class NpcEmotion : MonoBehaviour
    {
        [SerializeField] private GameObject _emotionCloud;
        [SerializeField] private SpriteRenderer _emotionImage;
        [SerializeField] private List<EmotionSO> _emotions;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _emotionCloud.SetActive(true);

                var randomEmotion = _emotions[UnityEngine.Random.Range(0, _emotions.Count)].Emotion;
                SetEmotion(randomEmotion);
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _emotionCloud.SetActive(false);
            }
        }

        private void SetEmotion(Emotion emotion)
        {
            var emotionObject = _emotions.Find(e => e.Emotion == emotion);
            _emotionImage.sprite = emotionObject.Sprite;
        }
    }
}