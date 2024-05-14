using System.Collections.Generic;
using Aili.Game;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Aili.Manager
{
    [AddComponentMenu("Aili/Manager/UI Manager")]
    public class UIManager : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField]
        TextMeshProUGUI m_ScoreText;

        [SerializeField]
        List<Image> m_HealthImages = new List<Image>();

        [SerializeField]
        List<RectTransform> m_GameOverScreen = new List<RectTransform>();

        GameManager gameManager;

        void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        void LateUpdate()
        {
            m_ScoreText.text = gameManager.score.ToString(); // update score
            for (int i = 0; i < m_HealthImages.Count; i++) // update health
            {
                if (i < gameManager.health)
                    m_HealthImages[i].transform.GetChild(0).gameObject.SetActive(true);
                else
                    m_HealthImages[i].transform.GetChild(0).gameObject.SetActive(false);
            }

            foreach (RectTransform screen in m_GameOverScreen)
            {
                if (gameManager.health <= 0)
                    screen.gameObject.SetActive(true);
            }
        }
    }
}
