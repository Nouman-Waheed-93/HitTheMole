using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;

    private void Start()
    {
        levelManager.onGameStart.AddListener(Hide);
    }
  
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ShowUp()
    {
        gameObject.SetActive(true);
    }
}
