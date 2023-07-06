using UnityEngine;

public class Shaking : State
{
    public Shaking(Hole hole, float minStayTime, float maxStayTime): base(hole, minStayTime, maxStayTime) 
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        hole.StartShaking();
    }

    public override void OnExit()
    {
        base.OnExit();
        hole.StopShaking();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
