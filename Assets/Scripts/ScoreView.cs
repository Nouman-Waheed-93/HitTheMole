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

    // Update is called once per frame
    void Update()
    {
        text.text = levelManager.Score.ToString();
    }
}
