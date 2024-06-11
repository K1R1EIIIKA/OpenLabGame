using System;
using UnityEngine;

namespace Kirill.Quest
{
    public class QuestItem : MonoBehaviour
    {
        [SerializeField] private GameObject _hintCanvas;
        [SerializeField] private QuestItemType _type;

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
                QuestLogic.Instance.AddItem(_type);
                Destroy(gameObject);
            }
        }
    }
}