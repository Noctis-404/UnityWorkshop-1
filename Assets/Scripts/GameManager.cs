using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text scoreText;
    public Text timerText;
    public GameObject gameOverPanel;

    [Header("Lives Setup")]
    public Image[] heartImages;    // Drag Heart1, Heart2, Heart3 UI Images here
    public Sprite fullHeart;       // Drag your Red Heart Sprite here
    public Sprite emptyHeart;      // Drag your Gray/Empty Heart Sprite here

    public float timeLeft = 60f;
    public int lives = 3;
    public int maxLives = 3;

    int score = 0;
    bool gameOver = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (scoreText != null) scoreText.text = "Score: 0";
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        UpdateHeartsDisplay();
    }

    void Update()
    {
        if (gameOver) return;

        timeLeft -= Time.deltaTime;
        timeLeft = Mathf.Max(0, timeLeft);

        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.CeilToInt(timeLeft);
        }

        if (timeLeft <= 0)
        {
            EndGame();
        }
    }

    public void AddScore(int amount)
    {
        if (gameOver) return;
        score += amount;
        if (scoreText != null) scoreText.text = "Score: " + score;
    }

    public void TakeDamage(int damage)
    {
        if (gameOver) return;

        lives -= damage;
        if (lives <= 0)
        {
            lives = 0;
            UpdateHeartsDisplay();
            GameOver();
        }
        else
        {
            UpdateHeartsDisplay();
        }
    }

    void GameOver()
    {
        gameOver = true;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        Time.timeScale = 0f;
    }

    public void AddLife(int amount)
    {
        if (gameOver) return;

        lives = Mathf.Clamp(lives + amount, 0, maxLives);
        UpdateHeartsDisplay();
    }

    void UpdateHeartsDisplay()
    {
        if (heartImages == null) return;

        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < lives)
            {
                heartImages[i].sprite = fullHeart;
            }
            else
            {
                heartImages[i].sprite = emptyHeart;
            }
        }
    }

    void EndGame()
    {
        gameOver = true;
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}