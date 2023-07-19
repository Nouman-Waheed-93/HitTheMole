using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IClickable
{
    [field: SerializeField]
    public Extremum fruitSpawnTime { get; private set; }

    [field: SerializeField]
    public  Extremum fruitRipeTime { get; private set; }

    [field: SerializeField]
    public Extremum fruitSize { get; private set; }

    [field: SerializeField]
    public FruitType fruitType { get; private set; }

    [SerializeField]
    public TreeFruit[] fruits;

    [SerializeField]
    private TreeSelectionManager selectionManager;

    private float spawnTime;

    private void Update()
    {
        if (!selectionManager.canSpawnFruits)
        {
            return;
        }

        if(spawnTime <= 0)
        {
            SpawnFruit();
        }
        spawnTime -= Time.deltaTime;
    }

    public void Clicked()
    {
        selectionManager.SelectTree(this);
    }

    public void Init(int fruitCount)
    {
        for(int i = 0; i < fruitCount; i++)
        {
            fruits[i].InstantRipe();
        }
        for(int i = fruitCount; i < fruits.Length; i++)
        {
            fruits[i].gameObject.SetActive(false);
        }
    }

    private void SpawnFruit()
    {
        foreach(TreeFruit fruit in fruits)
        {
            if (!fruit.gameObject.activeSelf)
            {
                fruit.Appear();
                spawnTime = fruitSpawnTime.GetRandomValue();
                return;
            }
        }
    }

    public bool RemoveARipeFruit()
    {
        foreach(TreeFruit fruit in fruits)
        {
            if (fruit.IsRipe)
            {
                fruit.Pick();
                return true;
            }
        }
        return false;
    }

    public void Select()
    {
        //Highlight
    }

    public void Deselect() 
    {
        //Un highlight
    }
}
