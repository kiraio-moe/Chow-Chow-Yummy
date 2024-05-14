using UnityEngine;

namespace Aili.Utils
{
    public static class Dimension
    {
        public static Vector2 GetScreenBounds()
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        }

        public static Vector2 GetSpriteBounds(SpriteRenderer spriteRenderer)
        {
            return spriteRenderer.bounds.size / 2;
        }
    }
}
