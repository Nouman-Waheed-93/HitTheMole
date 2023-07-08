using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BombFlash : MonoBehaviour
{
    [SerializeField]
    private Gradient explosionAnimation;
    private Image image;


    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void DoFlash()
    {
        gameObject.SetActive(true);
        float time = 0;
        DOTween.To(() => time, x => time = x, 1, 1).SetEase(Ease.Linear).OnUpdate( ()=>{ image.color = explosionAnimation.Evaluate(time); } ).OnComplete(()=> { gameObject.SetActive(false); });
    }
}
