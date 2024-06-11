using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kirill.Quest
{
    public class QuestLogic : MonoBehaviour
    {
        [SerializeField] private List<Quest> _quests;
        [SerializeField] private Quest _currentQuest;
        [SerializeField] private List<QuestItemType> _inventory;
        [SerializeField] private QuestUI _questUI;
        
        public static QuestLogic Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            _currentQuest = _quests[0];
            _currentQuest.CheckCompletion(_inventory);
            
            _questUI.UpdateQuestItems(_currentQuest, _inventory);
        }
        
        public void AddItem(QuestItemType item)
        {
            _inventory.Add(item);
            _questUI.UpdateQuestItems(_currentQuest, _inventory);
            _currentQuest.CheckCompletion(_inventory);
            if (_currentQuest.IsCompleted)
            {
                Debug.Log("Quest completed");
                if (_quests.IndexOf(_currentQuest) < _quests.Count - 1)
                {
                    _currentQuest = _quests[_quests.IndexOf(_currentQuest) + 1];
                    _inventory.Clear();
                    _questUI.UpdateQuestItems(_currentQuest, _inventory);
                }
            }
        }
    }
}