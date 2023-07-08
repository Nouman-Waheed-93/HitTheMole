using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected Hole hole;

    protected float minStayTime;
    protected float maxStayTime;

    protected float stayTime;
    public float StayTime { get => stayTime; }

    public State nextState { get; set; }

    public State(Hole hole, float minStayTime, float maxStayTime)
    {
        this.hole = hole;
        this.minStayTime = minStayTime;
        this.maxStayTime = maxStayTime;
    }

    public virtual void OnEnter()
    {
        stayTime = Random.Range(minStayTime, maxStayTime);
    }

    public virtual void OnUpdate()
    {
        stayTime -= Time.deltaTime;
        if(stayTime <= 0)
        {
            hole.ChangeState(nextState);
        }
        Debug.Log("My state is " + this.GetType());
    }

    public virtual void OnExit() { }
}
