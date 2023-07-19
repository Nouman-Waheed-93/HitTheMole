using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSelectionManager : MonoBehaviour
{
    [field: SerializeField]
    public Tree[] trees { get; private set; }

    public Tree selectedTree { get; private set; }

    public bool canSpawnFruits { get; private set; }

    public void Unselect()
    {
        selectedTree.Deselect();
        selectedTree = null;
    }

    public void SelectTree(Tree tree)
    {
        if(selectedTree != null && selectedTree == tree)
        {
            selectedTree.Deselect();
            return;
        }
        else if(selectedTree != null)
        {
            selectedTree.Deselect();
        }

        this.selectedTree = tree;

        selectedTree.Select();
    }

    public void OnGameStart()
    {
        canSpawnFruits = true;
        foreach(Tree tree in trees)
        {
            tree.Init(2);
        }
    }

    public void OnGameEnd()
    {
        canSpawnFruits = false;
    }
}
