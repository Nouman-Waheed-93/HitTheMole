using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleButton : MonoBehaviour
{
    [SerializeField]
    private GameObject selectionOutline;
    [SerializeField]
    private LevelManager levelManager;
    [SerializeField]
    private Text countText;

    private bool isSelected;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
        UpdateAppleCount();
        levelManager.onAppleCollected.AddListener(UpdateAppleCount);
        levelManager.onAppleUsed.AddListener(UpdateAppleCount);
        levelManager.onAppleUsed.AddListener(ToggleSelect);
    }

    private void OnClick()
    {
        ToggleSelect();
    }

    private void ToggleSelect()
    {
        isSelected = !isSelected;
        selectionOutline.SetActive(isSelected);
        levelManager.isAppleSelected = isSelected;
    }

    private void UpdateAppleCount()
    {
        if(levelManager.AppleCount <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
        countText.text = levelManager.AppleCount.ToString();
    }
}
