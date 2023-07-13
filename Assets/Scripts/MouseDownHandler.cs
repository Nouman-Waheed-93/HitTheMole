using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDownHandler : MonoBehaviour
{
    [SerializeField]
    private LayerMask moleLayer;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, float.MaxValue, moleLayer);

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null)
                {
                    hit.collider.GetComponent<IClickable>().Clicked();
                }
            }
        }
    }
}
