using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleOut : State
{
    public MoleOut(Hole hole, float minStayTime, float maxStayTime):base(hole, minStayTime, maxStayTime) { }

    public override void OnEnter()
    {
        base.OnEnter();
        stayTime *= hole.GetMolePower();
    }

    public override void OnUpdate()
    {
        stayTime -= Time.deltaTime;
        if (stayTime <= 0 && hole.CanGoIn())
        {
            hole.ChangeState(nextState);
        }
    }
}
