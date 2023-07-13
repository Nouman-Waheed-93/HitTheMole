using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesView : MonoBehaviour
{
    [SerializeField]
    private GameObject[] lives;
    [SerializeField]
    private LevelManager levelManager;

    private void Start()
    {
        levelManager.onLifeLost.AddListener(UpdateLifeView);
        levelManager.onGameStart.AddListener(UpdateLifeView);
    }

    private void UpdateLifeView()
    {
        for(int i = lives.Length - 1; i >= levelManager.Lives; i--)
        {
            lives[i].SetActive(false);
        }
    }
}
