using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoadButton : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;
    [SerializeField]
    private TextAsset levelFile;
    [SerializeField]
    private GameObject levelMenu;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        LevelDetails levelDetails = JsonUtility.FromJson<LevelDetails>(levelFile.text);
        if(levelDetails != null)
        {
            levelManager.levelDetails = levelDetails;
            levelManager.StartGame();
            levelMenu.SetActive(false);
        } 
    }
}
