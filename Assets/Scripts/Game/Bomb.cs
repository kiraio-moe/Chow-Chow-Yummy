using UnityEngine;

namespace Aili.Game
{
    [AddComponentMenu("Aili/Game/Bomb")]
    public class Bomb : Block
    {
        [Header("Interaction")]
        [SerializeField]
        string m_PlayerTag = "Player";
        [SerializeField]
        Sprite m_KaboomSprite;

        SpriteRenderer spriteRenderer;

        protected override void Awake()
        {
            base.Awake();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag(m_PlayerTag))
            {
                gameManager.AddHealth(-1);
                spriteRenderer.sprite = m_KaboomSprite;
            }
        }
    }
}
