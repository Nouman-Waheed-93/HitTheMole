using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelDetails levelDetails;

    private int molesOut;
    public int MolesOut
    {
        get => molesOut;
        set
        {
            if (value < 0)
            {
                molesOut = 0;
            }
            else if (value > levelDetails.maxMoles)
            {
                molesOut = levelDetails.maxMoles;
            }
            else 
            {
                molesOut = value;
            }
        }
    }

    public bool CanSendAMoleOut()
    {
        return molesOut < levelDetails.maxMoles;
    }
}
