using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour
{
    [SerializeField]
    private GameObject selectionOutline;
    [SerializeField]
    private LevelManager levelManager;

    private bool isSelected;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        isSelected = !isSelected;
        selectionOutline.SetActive(isSelected);
        levelManager.isAppleSelected = isSelected;
    }
}
