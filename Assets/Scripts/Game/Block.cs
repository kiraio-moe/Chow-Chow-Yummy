using Aili.Manager;
using Aili.Utils;
using UnityEngine;

namespace Aili.Game
{
    public abstract class Block : MonoBehaviour
    {
        public GameManager gameManager { get; private set; }

        protected virtual void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        void Update()
        {
            if (transform.position.y < (Dimension.GetScreenBounds().y - 10))
                Destroy(gameObject);
        }
    }
}
