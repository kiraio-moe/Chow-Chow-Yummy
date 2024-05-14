using System.Collections.Generic;
using Aili.Utils;
using Aili.Game;
using UnityEngine;
using TMPro;

namespace Aili.Manager
{
    [AddComponentMenu("Aili/Manager/Game Manager")]
    public class GameManager : MonoBehaviour
    {
        [Header("Game")]
        [SerializeField]
        SpriteRenderer m_FruitPrefab;
        [SerializeField]
        SpriteRenderer m_BombPrefab;

        [SerializeField, Range(0.1f, 3)]
        float m_FruitSpawnDelay = 0.3f;

        [SerializeField, Range(0.1f, 3)]
        float m_BombSpawnDelay = 1f;

        [SerializeField]
        List<FruitInfo> m_FruitVariants = new List<FruitInfo>();

        public bool isGameStarted { get; private set; }
        public int score { get; set; }
        public int health { get; set; } = 3;

        float fruitSpawnTimer, bombSpawnTimer;

        void Update()
        {
            fruitSpawnTimer += Time.deltaTime;
            bombSpawnTimer += Time.deltaTime;

            if (isGameStarted)
            {
                if (fruitSpawnTimer >= m_FruitSpawnDelay)
                {
                    SpawnFruit();
                    fruitSpawnTimer = 0;
                }
                if (bombSpawnTimer >= m_BombSpawnDelay)
                {
                    SpawnBomb();
                    bombSpawnTimer = 0;
                }
            }

            if (health <= 0)
            {
                isGameStarted = !isGameStarted;
                Time.timeScale = 0;

                Fruit[] fruits = FindObjectsOfType<Fruit>();
                Bomb[] bombs = FindObjectsOfType<Bomb>();
                foreach (Fruit fruit in fruits)
                    Destroy(fruit);
                foreach (Bomb bomb in bombs)
                    Destroy(bomb);
            }
        }

        public void StartGame()
        {
            if (!isGameStarted)
            {
                isGameStarted = true;
                fruitSpawnTimer = m_FruitSpawnDelay;
                bombSpawnTimer = m_BombSpawnDelay;
                health = 3;
                score = 0;
                Time.timeScale = 1;
            }
        }

        void SpawnFruit()
        {
            Vector2 spawnPos = GetSpawnPosition();
            int randomFruit = Random.Range(0, m_FruitVariants.Count);
            SpriteRenderer fruit = Instantiate(m_FruitPrefab, spawnPos, Quaternion.identity);
            fruit.sprite = m_FruitVariants[randomFruit].m_FruitSprite;
            fruit.GetComponent<Fruit>().fruitInfo = m_FruitVariants[randomFruit];
        }

        void SpawnBomb()
        {
            Vector2 spawnPos = GetSpawnPosition();
            Instantiate(m_BombPrefab, spawnPos, Quaternion.identity);
        }

        Vector2 GetSpawnPosition()
        {
            Vector2 screenBounds = Dimension.GetScreenBounds();
            return new Vector2(Random.Range(screenBounds.x * -1, screenBounds.x), screenBounds.y);
        }

        public void AddScore(int amount)
        {
            score += amount;
            if (score < 0) score = 0;
        }

        public void AddHealth(int amount)
        {
            health += amount;
            if (health < 0) health = 0;
        }
    }
}
