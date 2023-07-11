using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField]
    private Apple[] apples;
    [SerializeField]
    private Extremum spawnExtremes;

    private float spawnTimer;

    private void Awake()
    {
        SetSpawnTimer();    
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer < 0)
        {
            StartCoroutine(SpawnApple());
            SetSpawnTimer();
        }
    }

    private void SetSpawnTimer()
    {
        spawnTimer = Random.Range(spawnExtremes.minLimit, spawnExtremes.maxLimit);
    }

    private IEnumerator SpawnApple()
    {
        int appleIndex = Random.Range(0, apples.Length);
        while (apples[appleIndex].gameObject.activeSelf)
        {
            appleIndex++;
            appleIndex = appleIndex%apples.Length;
            yield return null;
        }
        apples[appleIndex].Fall();
    }
}
