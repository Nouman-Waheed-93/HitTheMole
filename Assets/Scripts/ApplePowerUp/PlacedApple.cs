using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedApple : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite;

    private float remainingTime;

    private Coroutine blinkCoroutine;

    private void OnEnable()
    {
        remainingTime = 3;
    }

    private void Update()
    {
        remainingTime -= Time.deltaTime;
        if(remainingTime <= 1)
        {
            if(blinkCoroutine == null)
            {
                blinkCoroutine = StartCoroutine(CrtnBlink());
            }
        }
    }

    private IEnumerator CrtnBlink()
    {
        float minBlinkTime = 0.1f;
        float maxBlinkTime = 0.3f;
        while (remainingTime > 0)
        {
            float blinkTime = Mathf.Clamp(remainingTime * 0.3f, minBlinkTime, maxBlinkTime);
            WaitForSeconds wait = new WaitForSeconds(blinkTime);
            sprite.color = Color.clear;
            yield return wait;
            sprite.color = Color.red;
            yield return wait;
        }
        gameObject.SetActive(false);
        blinkCoroutine = null;
    }

}
