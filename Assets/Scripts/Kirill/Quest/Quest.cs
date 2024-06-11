using System.Collections.Generic;
using UnityEngine;

namespace Kirill.Quest
{
    [CreateAssetMenu(fileName = "Quest", menuName = "Quest", order = 0)]
    public class Quest : ScriptableObject
    {
        [SerializeField] private List<QuestItemSO> _requiredItems;
        
        public List<QuestItemSO> RequiredItems => _requiredItems;
        
        public bool IsCompleted { get; private set; }
        
        public void CheckCompletion(List<QuestItemType> items)
        {
            IsCompleted = true;
            foreach (var requiredItem in _requiredItems)
            {
                if (!items.Contains(requiredItem.QuestItemType))
                {
                    IsCompleted = false;
                    break;
                }
            }
        }
    }
}