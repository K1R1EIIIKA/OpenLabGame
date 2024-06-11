using System.Collections.Generic;
using UnityEngine;

namespace Kirill.Quest
{
    public class QuestUI : MonoBehaviour
    {
        [SerializeField] private QuestItemUI _questItemUIPrefab;
        [SerializeField] private Transform _questItemsParent;

        public void UpdateQuestItems(Quest quest, List<QuestItemType> inventory)
        {
            foreach (Transform child in _questItemsParent)
            {
                Destroy(child.gameObject);
            }

            foreach (var requiredItem in quest.RequiredItems)
            {
                var questItemUI = Instantiate(_questItemUIPrefab, _questItemsParent);
                questItemUI.SetQuestItem(requiredItem);
                if (inventory.Contains(requiredItem.QuestItemType))
                {
                    Destroy(questItemUI.gameObject);
                }
            }
        }
    }
}