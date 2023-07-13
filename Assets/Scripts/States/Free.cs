using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Free : State
{
    public Free(Hole hole, float minStayTime, float maxStayTime) : base(hole, minStayTime, maxStayTime) { }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        stayTime -= Time.deltaTime;
        if (hole.isAppleOn)
        {
            stayTime = 0;
        }

        if (stayTime <= 0)
        {
            if (hole.CanSendAMoleOut())
            {
                hole.ChangeState(nextState);
                hole.BookMoleTurn();
            }
            else
            {
                stayTime = Random.Range(minStayTime, maxStayTime);
            }
        }
    }
}
