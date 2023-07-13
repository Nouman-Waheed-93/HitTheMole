using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    private Text text;
    [SerializeField]
    private LevelManager levelManager;

    void Update()
    {
        text.text = levelManager.Score.ToString();
    }
}
