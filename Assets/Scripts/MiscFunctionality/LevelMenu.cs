using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenu : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;

    private void Awake()
    {
        levelManager.onGameOver.AddListener(EnableLevelMenu);
    }

    private void EnableLevelMenu()
    {
        Invoke(nameof(CrtnShowUp), 1f);
    }

    private void CrtnShowUp()
    {
        gameObject.SetActive(true);
    }
}
