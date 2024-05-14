using UnityEngine;
using Aili.Utils;

namespace Aili.Player
{
    [AddComponentMenu("Aili/Player/Player Controller")]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        float m_MoveSpeed = 10f;

        Rigidbody2D rb;
        SpriteRenderer spriteRenderer;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void FixedUpdate()
        {
            MovePlayer();
            ClampPlayerPosition();
        }

        void MovePlayer()
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            // Calculate movement direction based on input
            Vector2 moveDirection = Vector2.zero;
            if (Input.GetMouseButton(0))
                moveDirection = (touchPos - transform.position);
            else if (horizontalInput != 0)
                moveDirection = Vector2.right * horizontalInput;

            // Apply movement
            rb.velocity = new Vector2(moveDirection.x * m_MoveSpeed, rb.velocity.y);
        }

        void ClampPlayerPosition()
        {
            // Get the screen boundaries in world coordinates
            Vector2 screenBounds = Dimension.GetScreenBounds();
            Vector2 spriteBounds = Dimension.GetSpriteBounds(spriteRenderer);

            // Clamp player's position
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, screenBounds.x * -1 + spriteBounds.x, screenBounds.x - spriteBounds.x), transform.position.y);
        }
    }
}
