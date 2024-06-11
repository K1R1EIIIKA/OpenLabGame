using UnityEngine;

namespace Kirill.Npc
{
    [CreateAssetMenu(fileName = "Emotion", menuName = "EmotionSO", order = 0)]
    public class EmotionSO : ScriptableObject
    {
        [SerializeField] private Emotion _emotion;
        [SerializeField] private Sprite _sprite;

        public Emotion Emotion => _emotion;
        public Sprite Sprite => _sprite;
    }
}