using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mole : MonoBehaviour, IClickable
{
    public Hole hole;
    private enum State { normal, crying, laughing, mesmerized, pirate }

    [SerializeField]
    private GameObject normalSprite;
    [SerializeField]
    private GameObject cryingSprite;
    [SerializeField]
    private GameObject laughingSprite;
    [SerializeField]
    private GameObject mesmerizedSprite;
    [SerializeField]
    private GameObject pirateSprite;

    [SerializeField]
    private float hitShakeInterval;
    [SerializeField]
    private float hitShakeStrength;

    [SerializeField]
    private float outThreshold;

    [SerializeField]
    private HitCountView simplePowerView;
    [SerializeField]
    private HitCountView complexPowerView;

    private State state = State.normal;

    private float randomActionTimer;

    private int power;
    public int Power { get => power; }

    public bool IsMesmerized
    {
        get
        {
            return state == State.mesmerized;
        }
    }

    public bool IsPirateMole
    {
        get
        {
            return state == State.pirate;
        }
    }

    private bool IsOut
    {
        get
        {
            return transform.localPosition.y >= outThreshold;
        }
    }

    private void Update()
    {
        randomActionTimer -= Time.deltaTime;
        if(randomActionTimer <= 0)
        {
            if(state == State.normal)
            {
                ToLaughingState();
            }
            else if(state == State.laughing)
            {
                ToNormalStateWithPower(power);
            }
        }
    }

    public void Clicked()
    {
        if (state == State.pirate)
            return;

        if (!IsOut)
            return;

        Debug.Log("Is out too");

        Debug.Log("Remaining power " + power);

        if (state == State.normal || state == State.laughing || state == State.mesmerized)
        {
            power--;
            if (power <= 0)
            {
                ToCryingState();
            }
        }
        else if(state == State.pirate)
        {
            if (power > 0)
            {
                hole.PirateMoleHit();
                hole.ChangeStateToCrying();
                power--;
            }
        }
    }

    public void ShowComplexPowerMole()
    {
        MathematicalOperation mathOp = (MathematicalOperation)Random.Range(0, 4);
        string equation;
        mathOp.CalculateNumbers(out power, out equation);
        ToNormalStateWithPower(power);
        complexPowerView.gameObject.SetActive(true);
        complexPowerView.ShowPower(equation);
    }

    public void HidePowerViews()
    {
        simplePowerView.gameObject.SetActive(false);
        complexPowerView.gameObject.SetActive(false);
    }

    public void ShowSimplePowerMole()
    {
        power = Random.Range(2, 10);
        ToNormalStateWithPower(power);
        Debug.Log("Simple power " + power);
        simplePowerView.gameObject.SetActive(true);
        simplePowerView.ShowPower(power.ToString());
    }

    public void ToNormalState()
    {
        ToNormalStateWithPower(1);
        simplePowerView.gameObject.SetActive(false);
        complexPowerView.gameObject.SetActive(false);
    }

    private void ToNormalStateWithPower(int power)
    {
        this.power = power;
        state = State.normal;
        EnableTheCorrectSprite();
        randomActionTimer = hole.CalculateRandomActionTime();
    }

    public void ToPirateNormalState()
    {
        power = 1;
        state = State.pirate;
        EnableTheCorrectSprite();
    }

    private void ToCryingState()
    {
        state = State.crying;
        hole.ChangeStateToCrying();
        EnableTheCorrectSprite();
    }

    public void ToMesmerizedState()
    {
        state = State.mesmerized;
        EnableTheCorrectSprite();
    }

    private void ToLaughingState()
    {
        state = State.laughing;
        EnableTheCorrectSprite();
        randomActionTimer = hole.CalculateRandomActionTime();
    }

    private void EnableTheCorrectSprite()
    {
        normalSprite.SetActive(false);
        cryingSprite.SetActive(false);
        laughingSprite.SetActive(false);
        mesmerizedSprite.SetActive(false);
        pirateSprite.SetActive(false);
        switch (state)
        {
            case State.crying:
                cryingSprite.SetActive(true);
                break;
            case State.mesmerized:
                mesmerizedSprite.SetActive(true);
                break;
            case State.laughing:
                laughingSprite.SetActive(true);
                break;
            case State.normal:
                normalSprite.SetActive(true);
                break;
            case State.pirate:
                pirateSprite.SetActive(true);
                break;
        }
    }
}
