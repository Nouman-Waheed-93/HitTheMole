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
        if (!hole.HasTheFavoriteFruit)
            return;

        stayTime -= Time.deltaTime;

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
