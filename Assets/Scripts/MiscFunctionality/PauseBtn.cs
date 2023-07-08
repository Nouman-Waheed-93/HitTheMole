using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseBtn : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnPauseClick);
    }

    private void OnPauseClick()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
