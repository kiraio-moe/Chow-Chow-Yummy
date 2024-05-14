using UnityEngine;

namespace Aili.Game
{
    [CreateAssetMenu(menuName = "Aili/Game/Fruit Info", fileName = "FruitInfo_")]
    public class FruitInfo : ScriptableObject
    {
        public Sprite m_FruitSprite;
        public FruitCondition m_FruitCondition;
        public enum FruitCondition { Good, Bad };
    }
}
