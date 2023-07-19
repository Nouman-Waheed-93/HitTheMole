using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedFruit : MonoBehaviour
{
    public FruitType fruitType { get; private set; }
    [SerializeField]
    private SpriteRenderer appleSprite;
    [SerializeField]
    private SpriteRenderer walnutSprite;

    private SpriteRenderer sprite;
    private float remainingTime;

    private Coroutine blinkCoroutine;

    public bool IsPlaced
    {
        get
        {
            return appleSprite.gameObject.activeSelf || walnutSprite.gameObject.activeSelf;
        }
    }

    private void Update()
    {
        HandleRemainingTime();   
    }

    private void HandleRemainingTime()
    {
        if (!IsPlaced)
            return;

        remainingTime -= Time.deltaTime;
        if (remainingTime <= 1)
        {
            if (blinkCoroutine == null)
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
            sprite.gameObject.SetActive(false);
            yield return wait;
            sprite.gameObject.SetActive(true);
            yield return wait;
        }
        sprite.gameObject.SetActive(false);
        blinkCoroutine = null;
    }

    public void Place(FruitType fruitType)
    {
        this.fruitType = fruitType;
        TurnOnCorrectFruitSprite();
        remainingTime = 10;
    }

    private void TurnOnCorrectFruitSprite()
    {
        appleSprite.gameObject.SetActive(false);
        walnutSprite.gameObject.SetActive(false);
        switch (fruitType)
        {
            case FruitType.Apple:
                sprite = appleSprite;
                break;
            case FruitType.Walnut:
                sprite = walnutSprite;
                break;
        }
        sprite.gameObject.SetActive(true);
    }
}
