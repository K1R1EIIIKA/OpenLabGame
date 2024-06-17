using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Kirill.Npc
{
    public class NpcEmotion : MonoBehaviour
    {
        [SerializeField] private GameObject _hintCanvas;
        [SerializeField] private List<GameObject> _emotionClouds;
        [SerializeField] private Vector2 _cloudOffset = new(0.31f, 0.57f);
        [SerializeField] private float _lifeTime = 3f;
        [SerializeField] private float _fadeTime = 0.75f;

        private bool _isTriggered;
        private bool _isCooldown;

        [SerializeField] private bool _isQuest;
        [SerializeField] private GameObject _questCanvas;

        [SerializeField] private Action _action;

        private void Awake()
        {
            foreach (var cloud in _emotionClouds)
            {
                foreach (var renderer in cloud.GetComponentsInChildren<SpriteRenderer>())
                {
                    renderer.DOFade(0, 0);
                }

                cloud.gameObject.SetActive(false);
            }
        }

        private void Start()
        {
            SetActiveQuestCanvas(_isQuest);
        }

        private void SetActiveQuestCanvas(bool isActive)
        {
            _questCanvas.SetActive(isActive);
        }

        public static void UpdateQuestCanvases()
        {
            var npcs = FindObjectsOfType<NpcEmotion>();
            foreach (var npc in npcs)
            {
                npc.SetActiveQuestCanvas(npc._isQuest);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !_isCooldown)
            {
                _questCanvas.SetActive(false);
                _hintCanvas.SetActive(true);
                _isTriggered = true;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !_isCooldown)
            {
                _questCanvas.SetActive(false);
                _hintCanvas.SetActive(true);
                _isTriggered = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (!_isCooldown) SetActiveQuestCanvas(_isQuest);

                _hintCanvas.SetActive(false);
                _isTriggered = false;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && _isTriggered && !_isCooldown)
            {
                _isCooldown = true;
                StartCoroutine(ShowEmotions());
                _hintCanvas.SetActive(false);
            }
        }

        private IEnumerator ShowEmotions()
        {
            DOVirtual.DelayedCall((_lifeTime + _fadeTime) * _emotionClouds.Count, () =>
            {
                _isCooldown = false;
                SetActiveQuestCanvas(_isQuest);
            });

            foreach (var cloud in _emotionClouds)
            {
                var cloudObject = Instantiate(cloud, transform.position + (Vector3)_cloudOffset, Quaternion.identity);
                ShowCloud(cloudObject);
                yield return new WaitForSeconds(_lifeTime + _fadeTime);
            }
        }

        private void ShowCloud(GameObject cloud)
        {
            if (_isQuest) _isQuest = false;

            cloud.gameObject.SetActive(true);
            _questCanvas.SetActive(false);

            foreach (var renderer in cloud.GetComponentsInChildren<SpriteRenderer>())
            {
                renderer.DOFade(1, _fadeTime);
            }

            DOVirtual.DelayedCall(_lifeTime, () => { HideCloud(cloud); });
        }

        private void HideCloud(GameObject cloud)
        {
            foreach (var renderer in cloud.GetComponentsInChildren<SpriteRenderer>())
            {
                renderer.DOFade(0, _fadeTime).OnComplete(() => { Destroy(cloud); });
            }
        }
    }
}