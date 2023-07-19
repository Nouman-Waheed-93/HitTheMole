using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSpawner : MonoBehaviour
{
    [SerializeField]
    private Hole holePrefab;
    [SerializeField]
    private LevelManager levelManager;

    public void SpawnHoles(int holeCount)
    {
        RemovePreviousHoles();
        List<int> indexList = new List<int>();
        for(int i = 0; i < transform.childCount; i++)
        {
            indexList.Add(i);
        }

        for (int i = 0; i < holeCount; i++)
        {
            int index = Random.Range(0, indexList.Count);
            Instantiate(holePrefab, transform.GetChild(indexList[index]), false).Init(levelManager);
            indexList.RemoveAt(index);
        }
    }

    private void RemovePreviousHoles()
    {
        Hole[] holeAlreadySpawned = transform.GetComponentsInChildren<Hole>();
        foreach (Hole hole in holeAlreadySpawned)
        {
            Destroy(hole.gameObject);
        }
    }
}
