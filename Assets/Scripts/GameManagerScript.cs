using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public delegate void RestartGameAction();
    public static event RestartGameAction OnRestartGame;

    private int score = 0;
    private int highscore = 0;
    private bool gameOver;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Enemy.OnEnemyDied += EnemyOnOnEnemyDied;
        EnemyGroupController.OnGameOver += GameOverOnOnGameOver;
        Player.OnPlayerDied += PlayerOnOnPlayerDied;
        scoreText.text = score.ToString().PadLeft(4,'0');
        highScoreText.text = highscore.ToString().PadLeft(4,'0');
        gameOver = false;
    }

    void Update()
    {
        
    }
    
    void OnDestroy()
    {
        Enemy.OnEnemyDied -= EnemyOnOnEnemyDied;
        EnemyGroupController.OnGameOver -= GameOverOnOnGameOver;
        Player.OnPlayerDied -= PlayerOnOnPlayerDied;
    }
    
    void EnemyOnOnEnemyDied(int points)
    {
        score += points;
        if (score > highscore)
        {
            highscore = score;
        }
        scoreText.text = score.ToString().PadLeft(4,'0');
        highScoreText.text = score.ToString().PadLeft(4,'0');
        
        
    }

    void PlayerOnOnPlayerDied()
    {
        if (!gameOver)
        {
            gameOver = true;
            RestartGame();
        }
    }

    void GameOverOnOnGameOver()
    {
        Debug.Log("Game Over");
        if (!gameOver)
        {
            gameOver = true;
            RestartGame();
        }
    }

    private IEnumerator RestartGame()
    {
        Debug.Log("Restarting Game");

        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(5f);
        score = 0;
        
        scoreText.text = score.ToString().PadLeft(4,'0');
        highScoreText.text = highscore.ToString().PadLeft(4,'0');
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        Time.timeScale = 1;
        
        OnRestartGame?.Invoke();
        gameOver = false;
    }
}
