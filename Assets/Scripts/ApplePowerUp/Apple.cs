using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Apple : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;
    [SerializeField]
    private Transform startPosition;
    [SerializeField]
    private Transform fallPosition;
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private float fallInterval;
    [SerializeField]
    private float expiryTime;
    [SerializeField]
    private float blinkTime;

    private float timeElapsed;

    private Coroutine blinkSequence;

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > blinkTime)
        {
            if(blinkSequence == null)
                StartBlinking();
        }
        if (timeElapsed > expiryTime)
            Expire();

    }

    private void OnMouseDown()
    {
        Collect();
    }


    private void Collect()
    {
        levelManager.CollectApple();
        gameObject.SetActive(false);
    }

    private void Expire()
    {
        gameObject.SetActive(false);
    }

    private void StartBlinking()
    {
        blinkSequence = StartCoroutine(CrtnBlink());
    }

    private void StopBlinking()
    {
        if (blinkSequence != null)
            StopCoroutine(blinkSequence);
    }

    private IEnumerator CrtnBlink()
    {
        while (true)
        {
            sprite.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sprite.color = Color.clear;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Fall()
    {
        gameObject.SetActive(true);
        sprite.color = Color.red;
        StopBlinking();
        transform.DOMove(fallPosition.position, fallInterval).SetEase(Ease.OutBounce).From(startPosition.position);
        timeElapsed = 0;
    }
}
