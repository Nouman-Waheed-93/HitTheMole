using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(LevelManager))]
public class LevelDataSaver : Editor
{
    public override void OnInspectorGUI()
    {
        LevelManager myTarget = (LevelManager)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Save Level"))
        {
            SaveLevel(myTarget);
        }

        if (GUILayout.Button("Load Level"))
        {
            LoadLevel(myTarget);
        }
    }

    private void SaveLevel(LevelManager myTarget)
    {
        string levelJson = JsonUtility.ToJson(myTarget.levelDetails);
        System.IO.File.WriteAllText(myTarget.levelSavePath, levelJson);
    }

    private void LoadLevel(LevelManager myTarget)
    {
        if (myTarget.levelToLoad == null)
            return;

        LevelDetails levelDetails = JsonUtility.FromJson<LevelDetails>(myTarget.levelToLoad.text);
        myTarget.levelSavePath = AssetDatabase.GetAssetPath(myTarget.levelToLoad);
        myTarget.levelDetails = levelDetails;
    }
}
