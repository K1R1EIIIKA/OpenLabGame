using UnityEngine;
using UnityEngine.UI;

namespace Kirill.Quest
{
    public class QuestItemUI : MonoBehaviour
    {
        private QuestItemType _questItemType;
        [SerializeField] private Image _image;
        
        public QuestItemType QuestItemType => _questItemType;

        public void SetQuestItem(QuestItemSO questItemType)
        {
            _questItemType = questItemType.QuestItemType;
            _image.sprite = questItemType.Sprite;
        }
    }
}