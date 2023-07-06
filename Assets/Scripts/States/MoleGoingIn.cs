using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleGoingIn : State
{
    public MoleGoingIn(Hole hole, float minStayTime, float maxStayTime) : base(hole, minStayTime, maxStayTime) { }

    public override void OnEnter()
    {
        base.OnEnter();
        hole.SendMoleIn(stayTime);
    }
}
