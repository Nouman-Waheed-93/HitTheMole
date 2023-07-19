using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TreeFruit : MonoBehaviour
{
    [SerializeField]
    private Tree tree;

    public bool IsRipe { get; set; }
    
    public void InstantRipe()
    {
        IsRipe = true;
        transform.localScale = Vector3.one * tree.fruitSize.maxLimit;
        gameObject.SetActive(true);
    }

    public void Appear()
    {
        IsRipe = false;
        transform.localScale = Vector3.one * tree.fruitSize.minLimit;
        gameObject.SetActive(true);
        float ripeTime = tree.fruitRipeTime.GetRandomValue();
        Vector3 maxSize = Vector3.one * tree.fruitSize.maxLimit;
        transform.DOPunchScale(Vector3.one, 0.5f).OnComplete(() => {
            transform.DOScale(maxSize, ripeTime).OnComplete(() => 
            {
                transform.DOPunchScale(Vector3.one * 0.4f, 0.5f);
                IsRipe = true;
            });
        });
    }

    public void Pick()
    {
        IsRipe = false;
        gameObject.SetActive(false);
    }
}
