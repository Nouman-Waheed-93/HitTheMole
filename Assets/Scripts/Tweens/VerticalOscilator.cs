using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalOscilator : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve animationCurve;

    private void Update()
    {
        Vector3 newPosition = transform.localPosition;
        newPosition.y = animationCurve.Evaluate(Time.time);
        transform.localPosition = newPosition;
    }
}
