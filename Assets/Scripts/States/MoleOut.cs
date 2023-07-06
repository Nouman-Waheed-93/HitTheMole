using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleOut : State
{
    public MoleOut(Hole hole, float minStayTime, float maxStayTime):base(hole, minStayTime, maxStayTime) { }
}
