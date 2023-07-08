using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCountView : MonoBehaviour
{
    [SerializeField]
    private TextMesh text;

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void ShowPower(string power)
    {
        text.text = power;
    }
}
