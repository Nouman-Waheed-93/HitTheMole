using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeView : MonoBehaviour
{
    [SerializeField]
    private LevelManager manager;
    [SerializeField]
    private Image image;

    void Update()
    {
        image.fillAmount = manager.timeFactor;
    }
}
