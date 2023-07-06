using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalOscilator : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve animationCurve;

    private void Update()
    {
        Vector3 newPosition = transform.localPosition;
        newPosition.x = animationCurve.Evaluate(Time.time);
        transform.localPosition = newPosition;
    }
}
