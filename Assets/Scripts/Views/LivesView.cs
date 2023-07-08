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
        levelManager.onLifeLost.AddListener(OnLifeLost);
    }

    private void OnLifeLost()
    {
        for(int i = lives.Length - 1; i >= levelManager.Lives; i--)
        {
            lives[i].SetActive(false);
        }
    }
}
