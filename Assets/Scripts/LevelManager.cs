using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public LevelDetails levelDetails;
    public string levelSavePath;
    public TextAsset levelToLoad;

    private int molesOut;
    public int MolesOut
    {
        get => molesOut;
        set
        {
            if (value < 0)
            {
                molesOut = 0;
            }
            else if (value > levelDetails.maxMoles)
            {
                molesOut = levelDetails.maxMoles;
            }
            else 
            {
                molesOut = value;
            }
        }
    }

    private float remainingTime;
    public float timeFactor { get => remainingTime / levelDetails.startTime; }

    private int score;
    public int Score { get => score; }

    private int lives;
    public int Lives { get => lives; }

    private int appleCount;
    public int AppleCount { get => appleCount; }

    private bool isGameOver = true;
    public bool IsGameOver { get => isGameOver; }

    public bool isAppleSelected { get; set; }

    public UnityEvent onLifeLost;
    public UnityEvent onAppleUsed;
    public UnityEvent onAppleCollected;
    public UnityEvent onGameOver;

    private bool gameOverEventRaised;

    private void Awake()
    {
        lives = levelDetails.lives;
        remainingTime = levelDetails.startTime;
    }

    private void Update()
    {
        if (isGameOver)
            return;

        remainingTime -= Time.deltaTime;
        if(remainingTime <= 0)
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        isGameOver = false;
        remainingTime = levelDetails.startTime;
    }

    public void CollectApple()
    {
        appleCount++;
        onAppleCollected?.Invoke();
    }

    public void UsedApple()
    {
        appleCount--;
        onAppleUsed?.Invoke();
    }

    public bool CanSendAMoleOut()
    {
        return molesOut < levelDetails.maxMoles && !isGameOver;
    }

    public void MoleHit()
    {
        if (isGameOver)
            return;

        score++;
    }

    public void LoseLife()
    {
        lives--;
        onLifeLost?.Invoke();
        if(lives <= 0)
        {
            //Mar gya
            GameOver();
        }
    }

    private void GameOver()
    {
        if (!gameOverEventRaised)
        {
            gameOverEventRaised = true;
            isGameOver = true;
            onGameOver?.Invoke();
        }
    }
}
