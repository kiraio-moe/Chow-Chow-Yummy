using UnityEngine;
using Aili.Utils;
using Aili.Manager;

namespace Aili.Game
{
    [AddComponentMenu("Aili/Game/Fruit")]
    public class Fruit : Block
    {
        [Header("Interaction")]
        [SerializeField]
        string m_PlayerTag = "Player";

        public FruitInfo fruitInfo { get; set; }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(m_PlayerTag))
            {
                switch (fruitInfo.m_FruitCondition)
                {
                    case FruitInfo.FruitCondition.Good:
                        gameManager.AddScore(1);
                        break;
                    case FruitInfo.FruitCondition.Bad:
                        gameManager.AddScore(-1);
                        break;
                }
            }
        }
    }
}
