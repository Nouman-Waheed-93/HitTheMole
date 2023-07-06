using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hole : MonoBehaviour
{
    [SerializeField]
    LevelManager levelManager;

    [SerializeField]
    private Mole mole;

    [SerializeField]
    private float shakingStrength;
    [SerializeField]
    private float shakingInterval;

    private State currentState;
    private Free stateFree;
    private Shaking stateShaking;
    private MoleGoingOut stateGoingOut;
    private MoleOut stateMoleOut;
    private MoleOut stateMoleCrying;
    private MoleGoingIn stateMoleIn;

    private Sequence shakeSequence;
    private Vector3 originPosition;

    private void Awake()
    {
        stateFree = new Free(this, levelManager.levelDetails.moleOutInterval.minLimit, levelManager.levelDetails.moleOutInterval.maxLimit);
        stateShaking = new Shaking(this, levelManager.levelDetails.shakeInterval.minLimit, levelManager.levelDetails.shakeInterval.maxLimit);
        stateGoingOut = new MoleGoingOut(this, levelManager.levelDetails.jumpUpTime.minLimit, levelManager.levelDetails.jumpUpTime.maxLimit);
        stateMoleOut = new MoleOut(this, levelManager.levelDetails.stayTime.minLimit, levelManager.levelDetails.stayTime.maxLimit);
        stateMoleCrying = new MoleOut(this, 0.5f, 0.5f);
        stateMoleIn = new MoleGoingIn(this, levelManager.levelDetails.goDownTime.minLimit, levelManager.levelDetails.goDownTime.maxLimit);

        stateFree.nextState = stateShaking;
        stateShaking.nextState = stateGoingOut;
        stateGoingOut.nextState = stateMoleOut;
        stateMoleOut.nextState = stateMoleIn;
        stateMoleCrying.nextState = stateMoleIn;
        stateMoleIn.nextState = stateFree;
        currentState = stateFree;
        originPosition = transform.position;
    }

    private void Update()
    {
        currentState.OnUpdate();
    }

    public void SendAMoleOut(float time)
    {
        DecideMoleType();
        mole.transform.position = transform.position;
        mole.transform.DOLocalMoveY(2, time);
    }

    public void SendMoleIn(float time)
    {
        mole.HidePowerViews();
        mole.transform.DOLocalMoveY(-1, time);
    }

    public void StartShaking()
    {
        shakeSequence = DOTween.Sequence();
        shakeSequence.Append(transform.DOMoveY(originPosition.y + shakingStrength, shakingInterval));
        shakeSequence.Append(transform.DOMoveY(originPosition.y - shakingStrength, shakingInterval));
        shakeSequence.SetLoops(int.MaxValue);
    }

    public void StopShaking()
    {
        shakeSequence?.Kill();
    }

    public void ChangeStateToCrying()
    {
        ChangeState(stateMoleCrying);
    }

    public void ChangeState(State state)
    {
        currentState.OnExit();
        currentState = state;
        currentState.OnEnter();
    }

    public float CalculateRandomActionTime()
    {
        return Random.Range(currentState.StayTime * 0.1f, currentState.StayTime);
    }

    private void DecideMoleType()
    {
        float decider = Random.Range(0f, 1f);
        float simplePowerMoleProbability = levelManager.levelDetails.simplePowerMoleProbability;
        float complexPowerMoleProbability = levelManager.levelDetails.complexPowerMoleProbability;
        float pirateMoleProbability = levelManager.levelDetails.pirateMoleProbability;
        float normalMoleProbability = 1 - simplePowerMoleProbability 
            - complexPowerMoleProbability 
            - pirateMoleProbability;

        if (decider < normalMoleProbability) { mole.ToNormalState(); }
        else if(decider < normalMoleProbability + simplePowerMoleProbability) { mole.ShowSimplePowerMole(); }
        else if(decider < normalMoleProbability + simplePowerMoleProbability + pirateMoleProbability) { mole.ToPirateNormalState(); }
        else { mole.ShowComplexPowerMole(); }
    }

}
