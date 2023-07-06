public class MoleGoingOut : State
{
    public MoleGoingOut(Hole hole, float minStayTime, float maxStayTime):base(hole, minStayTime, maxStayTime)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();
        hole.SendAMoleOut(stayTime);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
