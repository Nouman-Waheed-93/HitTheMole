using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public LevelDetails levelDetails;

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

    public bool isAppleSelected { get; set; }

    public UnityEvent onLifeLost;

    private void Awake()
    {
        lives = levelDetails.lives;
        remainingTime = levelDetails.startTime;
    }

    private void Update()
    {
        remainingTime -= Time.deltaTime;
    }

    public bool CanSendAMoleOut()
    {
        return molesOut < levelDetails.maxMoles;
    }

    public void MoleHit()
    {
        score++;
    }

    public void LoseLife()
    {
        lives--;
        onLifeLost?.Invoke();
        if(lives <= 0)
        {
            //Mar gya
        }
    }
}
