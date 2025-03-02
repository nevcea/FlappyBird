using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("References")]
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;

    private int score;
    private bool isGameOver;
    private Vector3 playerStartPosition;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        Application.targetFrameRate = 60;
        playerStartPosition = player.transform.position;
        Pause();
    }

    public void Play()
    {
        isGameOver = false;
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        player.transform.position = playerStartPosition;

        CleanupPipes();
        Time.timeScale = 1f;
        player.enabled = true;
    }

    private void CleanupPipes()
    {
        foreach (var pipe in FindObjectsOfType<Pipes>())
        {
            Destroy(pipe.gameObject);
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        SoundManager.Instance.PlayDie();
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }

    public void IncreaseScore()
    {
        if (isGameOver) return;

        score++;
        scoreText.text = score.ToString();
        SoundManager.Instance.PlayPoint();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
}