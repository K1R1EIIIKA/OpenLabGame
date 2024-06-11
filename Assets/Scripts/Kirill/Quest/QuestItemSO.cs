using UnityEngine;

namespace Kirill.Quest
{
    [CreateAssetMenu(fileName = "QuestItem", menuName = "QuestItemSO", order = 0)]
    
    public class QuestItemSO : ScriptableObject
    {
        [SerializeField] private QuestItemType _questItemType;
        [SerializeField] private Sprite _sprite;

        public QuestItemType QuestItemType => _questItemType;
        public Sprite Sprite => _sprite;
    }
}